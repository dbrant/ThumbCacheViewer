using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

// Thumbnail cache decoder
// Copyright (c) 2018 Dmitry Brant, all rights reserved
// http://dmitrybrant.com
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
    public class ThumbCache
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

        ~ThumbCache()
        {
            stream.Close();
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
        
        public Image GetImage(int imageIndex)
        {
            Image img = null;
            if (entryOffsets.Length == 0) return img;
            if ((imageIndex < 0) || (imageIndex >= entryOffsets.Length)) return img;

            stream.Seek(entryOffsets[imageIndex], SeekOrigin.Begin);
            stream.Read(tempBytes, 0, 28);
            string magic = Encoding.ASCII.GetString(tempBytes, 0, 4);
            if (!magic.Equals("CMMM"))
                return img;
            
            uint entrySize = BitConverter.ToUInt32(tempBytes, 4);
            uint dataSize = fileVersion == WindowsVista ? BitConverter.ToUInt32(tempBytes, 28) : BitConverter.ToUInt32(tempBytes, 24);
            
            if (dataSize == 0) return img;

            stream.Seek(entryOffsets[imageIndex] + entrySize - dataSize, SeekOrigin.Begin);

            if (dataSize > tempBytes.Length)
                tempBytes = new byte[dataSize];

            stream.Read(tempBytes, 0, (int)dataSize);
            var mstream = new MemoryStream(tempBytes);
            img = new Bitmap(mstream);
            return img;
        }

    }

}
