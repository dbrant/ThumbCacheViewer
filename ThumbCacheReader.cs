using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

// Thumbnail cache decoder
// Copyright (c) 2018-2021 Dmitry Brant, all rights reserved
// https://dmitrybrant.com
// me@dmitrybrant.com

// This source code is free for personal use.
// For commercial use, please contact the developer to
// purchase a license.

// This Software is provided "as-is," without any express or 
// implied warranty, without even the implied warranty of 
// merchantability and fitness for a particular purpose. In 
// no event shall the Author be held liable for any, direct or 
// indirect, damages arising from the use of the Software.

namespace ThumbCacheViewer
{
    public class ThumbCache : IDisposable
    {
        private const int WindowsVista = 0x14;
        private const int Windows7 = 0x15;
        private const int Windows8 = 0x1A;
        private const int Windows8v2 = 0x1C;
        private const int Windows8v3 = 0x1E;
        private const int Windows8_1 = 0x1F;
        private const int Windows10 = 0x20;

        private Stream stream;
        private uint fileVersion;

        private byte[] tempBytes = new byte[65536];
        private uint[] entryOffsets;

        public int ImageCount { get { return entryOffsets.Length; } }

        public ThumbCache(string fileName)
        {
            stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            ReadFromStream(stream);
        }

        public ThumbCache(Stream stream)
        {
            ReadFromStream(stream);
        }

        public void Dispose()
        {
            stream.Dispose();
            
        }

        private void ReadFromStream(Stream stream)
        {
            stream.Read(tempBytes, 0, 32);

            string magic = Encoding.ASCII.GetString(tempBytes, 0, 4);
            if (!magic.Equals("CMMM"))
                throw new ApplicationException("This is not a valid ThumbCache file.");

            fileVersion = BitConverter.ToUInt32(tempBytes, 4);
            uint fileType = BitConverter.ToUInt32(tempBytes, 8);

            uint firstEntryPtr = 0;
            uint availableEntryPtr = 0;
            if (fileVersion < Windows8v2)
            {
                firstEntryPtr = BitConverter.ToUInt32(tempBytes, 12);
                availableEntryPtr = BitConverter.ToUInt32(tempBytes, 16);
            }
            else
            {
                firstEntryPtr = BitConverter.ToUInt32(tempBytes, 16);
                availableEntryPtr = BitConverter.ToUInt32(tempBytes, 20);
            }

            stream.Seek(firstEntryPtr, SeekOrigin.Begin);

            List<uint> entryOffsetList = new List<uint>();

            try
            {
                uint entrySize;
                while (stream.Position < stream.Length)
                {
                    entryOffsetList.Add((uint)stream.Position);

                    stream.Read(tempBytes, 0, 8);
                    if ((tempBytes[0] != 'C') || (tempBytes[1] != 'M') || (tempBytes[2] != 'M') || (tempBytes[3] != 'M'))
                        break;

                    entrySize = BitConverter.ToUInt32(tempBytes, 4);
                    stream.Seek(entrySize - 8, SeekOrigin.Current);
                }
            }
            catch { }

            entryOffsets = entryOffsetList.ToArray();
        }

        public ThumbInfo GetImage(int imageIndex, bool needImage)
        {
            if (entryOffsets.Length == 0) return null;
            if ((imageIndex < 0) || (imageIndex >= entryOffsets.Length)) return null;
            return new ThumbInfo(stream, entryOffsets[imageIndex], tempBytes, fileVersion, needImage);
        }

        public Dictionary<string, string> GetMetadata(ThumbInfo info)
        {
            var dict = new Dictionary<string, string>();
            if (entryOffsets.Length == 0) return dict;
            if (info == null) return dict;

            dict.Add("File offset", info.fileOffset.ToString());
            dict.Add("Entry size", info.entrySize.ToString());
            dict.Add("Entry hash", info.entryHash.ToString("X16"));
            dict.Add("Filename length", info.fileNameLength.ToString());
            dict.Add("Padding length", info.paddingLength.ToString());
            dict.Add("Data length", info.dataLength.ToString());
            dict.Add("Image width", info.imageWidth.ToString());
            dict.Add("Image height", info.imageHeight.ToString());
            dict.Add("Data checksum", info.dataChecksum.ToString("X16"));
            dict.Add("Header checksum", info.headerChecksum.ToString("X16"));
            return dict;
        }


        public class ThumbInfo : IDisposable
        {
            public Image image;
            public long fileOffset;
            public uint entrySize;
            public ulong entryHash;
            public uint fileNameLength;
            public uint paddingLength;
            public uint dataLength;
            public ulong dataChecksum;
            public ulong headerChecksum;
            public uint imageWidth;
            public uint imageHeight;

            public ThumbInfo(Stream stream, long offset, byte[] tempBytes, uint fileVersion, bool needImage)
            {
                fileOffset = offset;
                stream.Seek(fileOffset, SeekOrigin.Begin);
                stream.Read(tempBytes, 0, 64);

                int bytePtr = 0;
                string magic = Encoding.ASCII.GetString(tempBytes, bytePtr, 4); bytePtr += 4;
                if (!magic.Equals("CMMM"))
                    throw new ApplicationException("Incorrect format.");

                entrySize = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;
                entryHash = BitConverter.ToUInt64(tempBytes, bytePtr); bytePtr += 8;

                if (fileVersion == WindowsVista)
                {
                    bytePtr += 8; // wchar x 4
                }

                fileNameLength = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;
                paddingLength = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;
                dataLength = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;

                if (fileVersion >= Windows8)
                {
                    imageWidth = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;
                    imageHeight = BitConverter.ToUInt32(tempBytes, bytePtr); bytePtr += 4;
                }

                bytePtr += 4; // unknown

                dataChecksum = BitConverter.ToUInt64(tempBytes, bytePtr); bytePtr += 8;
                headerChecksum = BitConverter.ToUInt64(tempBytes, bytePtr); bytePtr += 8;

                if (!needImage || dataLength == 0 || dataLength > 0x1000000)
                    return;
                
                stream.Seek(fileOffset + entrySize - dataLength, SeekOrigin.Begin);
                if (dataLength > tempBytes.Length)
                    tempBytes = new byte[dataLength];

                stream.Read(tempBytes, 0, (int)dataLength);

                // Only bother decoding the image if it matches these formats.
                if (((tempBytes[0] == 0x42) && (tempBytes[1] == 0x4D)) // BMP
                    || ((tempBytes[0] == 0xFF) && (tempBytes[1] == 0xD8)) // JPG
                    || ((tempBytes[0] == 0x89) && (tempBytes[1] == 0x50))) // PNG
                {
                    using (var mstream = new MemoryStream(tempBytes))
                    {
                        image = new Bitmap(mstream);
                    }
                }
            }

            public void Dispose()
            {
                if (image != null)
                {
                    try { image.Dispose(); } catch { }
                }
            }
        }
    }
}
