using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

// Thumbnail cache viewer
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
    public partial class Form1 : Form
    {
        ThumbCache cache;

        public Form1()
        {
            InitializeComponent();
            FixDialogFont(this);
            FixWindowTheme(lstCacheFiles);
            FixWindowTheme(listViewEntries);
            FixWindowTheme(lstProperties);
            this.Text = Application.ProductName;


            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            userDir += "\\Microsoft\\Windows\\Explorer";
            List<string> dbFiles = new List<string>();

            FindDbFiles(userDir, ref dbFiles);

            foreach (var dbFile in dbFiles)
            {
                lstCacheFiles.Items.Add(dbFile, "pictures");
            }

            setViewAsThumbs(true);
        }

        private void FindDbFiles(string path, ref List<string> dbFiles)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path, "thumbcache*.db");

                for (int i = 0; i < files.Length; i++)
                    dbFiles.Add(files[i]);

                for (int i = 0; i < dirs.Length; i++)
                    FindDbFiles(dirs[i], ref dbFiles);

            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Thumbnail Cache Viewer\nCopyright 2021 Dmitry Brant.", "About...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog();
            openDlg.DefaultExt = ".lfp";
            openDlg.CheckFileExists = true;
            openDlg.Title = "Open thumbnail cache file...";
            openDlg.Filter = "Thumbnail cache files (*.db)|*.db|All Files (*.*)|*.*";
            openDlg.FilterIndex = 1;
            if (openDlg.ShowDialog() == DialogResult.Cancel) return;
            OpenFile(openDlg.FileName);
        }

        private void lstCacheFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCacheFiles.SelectedItems.Count == 0) return;
            OpenFile(lstCacheFiles.SelectedItems[0].Text);
        }

        private void OpenFile(string fileName)
        {
            try
            {
                cache = new ThumbCache(fileName);

                listViewEntries.LargeImageList = null;
                int w = 120;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        var img = cache.GetImage(i, true);
                        w = img.image.Width;
                        if (img.image.Height > w) w = img.image.Height;
                    }
                    catch { }
                }

                if (w < 32) { w = 32; }
                if (w > 240) { w = 240; }

                w += 16;

                imageList1.ImageSize = new Size(w, w);
                listViewEntries.LargeImageList = imageList1;

                listViewEntries.VirtualListSize = cache.ImageCount;
                listViewEntries.Invalidate();

                this.Text = Application.ProductName + " - " + fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawBackground();
            e.DrawDefault = true;
            //e.DrawText();

            Image img = null;
            try
            {
                img = cache.GetImage(e.ItemIndex, true).image;
            } catch { }
            if (img == null) return;

            float aspect = (float)img.Width / (float)img.Height;
            if (aspect == 0f) { aspect = 1f; }
            Rectangle src = new Rectangle(0, 0, img.Width, img.Height);
            Rectangle dst;


            if (aspect >= 1f)
            {
                // width >= height
                if (img.Width > e.Bounds.Width)
                {
                    dst = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, (int)(e.Bounds.Height / aspect));
                }
                else
                {
                    dst = new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 - img.Width / 2, e.Bounds.Top + e.Bounds.Height / 2 - img.Height / 2, img.Width, img.Height);
                }
            }
            else
            {
                // height > width
                if (img.Height > e.Bounds.Height)
                {
                    dst = new Rectangle(e.Bounds.Left, e.Bounds.Top, (int)(e.Bounds.Width * aspect), e.Bounds.Height);
                }
                else
                {
                    dst = new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 - img.Width / 2, e.Bounds.Top + e.Bounds.Height / 2 - img.Height / 2, img.Width, img.Height);
                }
            }
            
            e.Graphics.DrawImage(img, dst, src, GraphicsUnit.Pixel);
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem();
            if (listViewEntries.View != View.Details)
            {
                return;
            }
            e.Item.ImageIndex = 5;
            ThumbCache.ThumbInfo img = null;
            try
            {
                img = cache.GetImage(e.ItemIndex, false);
            }
            catch { }
            if (img == null)
            {
                e.Item.Text = "";
                e.Item.SubItems.Add("");
                e.Item.SubItems.Add("");
                e.Item.SubItems.Add("");
                e.Item.SubItems.Add("");
                e.Item.SubItems.Add("");
                e.Item.SubItems.Add("");
                return;
            }
            e.Item.Text = img.fileOffset.ToString();
            e.Item.SubItems.Add(img.entrySize.ToString());
            e.Item.SubItems.Add(img.entryHash.ToString("X16"));
            e.Item.SubItems.Add(img.fileNameLength.ToString());
            e.Item.SubItems.Add(img.dataLength.ToString());
            e.Item.SubItems.Add(img.dataChecksum.ToString("X16"));
            e.Item.SubItems.Add(img.headerChecksum.ToString("X16"));
        }

        private void listViewEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEntries.SelectedIndices.Count == 0)
            {
                return;
            }
            lstProperties.Items.Clear();
            pictureBox1.Image = null;
            try
            {
                var info = cache.GetImage(listViewEntries.SelectedIndices[0], true);
                var dict = cache.GetMetadata(info);
                foreach (var key in dict.Keys)
                {
                    var item = lstProperties.Items.Add(key);
                    item.ImageKey = "information";
                    item.SubItems.Add(dict[key]);
                }
                pictureBox1.Image = info.image;
            }
            catch { }
        }

        private void mnuSaveSelected_Click(object sender, EventArgs e)
        {
            if (listViewEntries.SelectedIndices.Count == 0)
            {
                MessageBox.Show(this, "Please select one or more images to save.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string selectedPath = "";
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.ShowNewFolderButton = true;
                dlg.Description = "Select the folder where the images will be saved:";
                if (dlg.ShowDialog(this) != DialogResult.OK) { return; }
                selectedPath = dlg.SelectedPath;
            }

            try
            {
                int filesSaved = 0;
                foreach (int itemIndex in listViewEntries.SelectedIndices)
                {
                    ThumbCache.ThumbInfo img = null;
                    try
                    {
                        img = cache.GetImage(itemIndex, true);
                    }
                    catch { }
                    if (img == null) continue;

                    var fileName = Path.Combine(selectedPath, img.entryHash.ToString("X16") + ".png");
                    using (var bmp = new Bitmap(img.image))
                    {
                        bmp.Save(fileName, ImageFormat.Png);
                    }
                    filesSaved++;
                }
                MessageBox.Show(this, "Successfully saved " + filesSaved + " file(s).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error while saving file: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /// <summary>
        /// Sets the font of a given control, and all child controls, to
        /// the current system font, while preserving font styles.
        /// </summary>
        /// <param name="c0">Control whose font will be set.</param>
        public static void FixDialogFont(Control c0)
        {
            foreach (Control c in c0.Controls)
            {
                Font old = c.Font;
                c.Font = new Font(SystemFonts.MessageBoxFont.FontFamily.Name, old.Size, old.Style);
                if (c.Controls.Count > 0)
                    FixDialogFont(c);
            }
        }
        
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        /// <summary>
        /// Sets the proper visual style for a ListView or TreeView control, so that it looks
        /// more like the list control in Explorer.
        /// </summary>
        /// <param name="lv">ListView or TreeView control to fix.</param>
        public static void FixWindowTheme(Control ctl)
        {
            SetWindowTheme(ctl.Handle, "Explorer", null);
        }



        private void mnuViewAsThumbs_Click(object sender, EventArgs e)
        {
            setViewAsThumbs(true);
        }

        private void mnuViewAsList_Click(object sender, EventArgs e)
        {
            setViewAsThumbs(false);
        }

        private void setViewAsThumbs(bool thumbs)
        {
            mnuViewAsThumbs.Checked = thumbs;
            mnuViewAsList.Checked = !thumbs;
            listViewEntries.View = thumbs ? View.LargeIcon : View.Details;
            listViewEntries.OwnerDraw = thumbs;
        }
    }
}
