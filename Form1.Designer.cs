namespace ThumbCacheViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new System.Windows.Forms.ImageList(components);
            imageList2 = new System.Windows.Forms.ImageList(components);
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            mnuSaveSelected = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewAsThumbs = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewAsList = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            listViewEntries = new ListViewDblBuf();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader7 = new System.Windows.Forms.ColumnHeader();
            columnHeader8 = new System.Windows.Forms.ColumnHeader();
            columnHeader9 = new System.Windows.Forms.ColumnHeader();
            columnHeader10 = new System.Windows.Forms.ColumnHeader();
            splitter3 = new System.Windows.Forms.Splitter();
            panel3 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            splitter2 = new System.Windows.Forms.Splitter();
            lstProperties = new ListViewDblBuf();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            splitter1 = new System.Windows.Forms.Splitter();
            lstCacheFiles = new ListViewDblBuf();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList1.ImageSize = new System.Drawing.Size(16, 16);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = System.Drawing.Color.Transparent;
            imageList2.Images.SetKeyName(0, "pictures");
            imageList2.Images.SetKeyName(1, "information");
            imageList2.Images.SetKeyName(2, "graydot");
            imageList2.Images.SetKeyName(3, "openimage");
            imageList2.Images.SetKeyName(4, "save");
            imageList2.Images.SetKeyName(5, "imagemedium");
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1093, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, toolStripMenuItem1, mnuSaveSelected, toolStripMenuItem2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
            // 
            // mnuSaveSelected
            // 
            mnuSaveSelected.Image = (System.Drawing.Image)resources.GetObject("mnuSaveSelected.Image");
            mnuSaveSelected.Name = "mnuSaveSelected";
            mnuSaveSelected.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            mnuSaveSelected.Size = new System.Drawing.Size(234, 22);
            mnuSaveSelected.Text = "Save selected images...";
            mnuSaveSelected.Click += mnuSaveSelected_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(231, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            exitToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuViewAsThumbs, mnuViewAsList });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // mnuViewAsThumbs
            // 
            mnuViewAsThumbs.Checked = true;
            mnuViewAsThumbs.CheckState = System.Windows.Forms.CheckState.Checked;
            mnuViewAsThumbs.Name = "mnuViewAsThumbs";
            mnuViewAsThumbs.Size = new System.Drawing.Size(150, 22);
            mnuViewAsThumbs.Text = "As thumbnails";
            mnuViewAsThumbs.Click += mnuViewAsThumbs_Click;
            // 
            // mnuViewAsList
            // 
            mnuViewAsList.Name = "mnuViewAsList";
            mnuViewAsList.Size = new System.Drawing.Size(150, 22);
            mnuViewAsList.Text = "As list";
            mnuViewAsList.Click += mnuViewAsList_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatus });
            statusStrip1.Location = new System.Drawing.Point(0, 719);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1093, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(lstCacheFiles);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 24);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1093, 695);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(listViewEntries);
            panel2.Controls.Add(splitter3);
            panel2.Controls.Add(panel3);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 151);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1093, 544);
            panel2.TabIndex = 5;
            // 
            // listViewEntries
            // 
            listViewEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            listViewEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewEntries.FullRowSelect = true;
            listViewEntries.Location = new System.Drawing.Point(0, 0);
            listViewEntries.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listViewEntries.Name = "listViewEntries";
            listViewEntries.OwnerDraw = true;
            listViewEntries.Size = new System.Drawing.Size(820, 544);
            listViewEntries.SmallImageList = imageList2;
            listViewEntries.TabIndex = 7;
            listViewEntries.UseCompatibleStateImageBehavior = false;
            listViewEntries.VirtualMode = true;
            listViewEntries.DrawItem += listView1_DrawItem;
            listViewEntries.RetrieveVirtualItem += listView1_RetrieveVirtualItem;
            listViewEntries.SelectedIndexChanged += listViewEntries_SelectedIndexChanged;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "File offset";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Entry size";
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Entry hash";
            columnHeader6.Width = 132;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Filename length";
            columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Data length";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Data checksum";
            columnHeader9.Width = 132;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Header checksum";
            columnHeader10.Width = 132;
            // 
            // splitter3
            // 
            splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            splitter3.Location = new System.Drawing.Point(820, 0);
            splitter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter3.Name = "splitter3";
            splitter3.Size = new System.Drawing.Size(5, 544);
            splitter3.TabIndex = 6;
            splitter3.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(splitter2);
            panel3.Controls.Add(lstProperties);
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(825, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(268, 544);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(268, 167);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // splitter2
            // 
            splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            splitter2.Location = new System.Drawing.Point(0, 167);
            splitter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter2.Name = "splitter2";
            splitter2.Size = new System.Drawing.Size(268, 5);
            splitter2.TabIndex = 3;
            splitter2.TabStop = false;
            // 
            // lstProperties
            // 
            lstProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader2, columnHeader3 });
            lstProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            lstProperties.Location = new System.Drawing.Point(0, 172);
            lstProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lstProperties.MultiSelect = false;
            lstProperties.Name = "lstProperties";
            lstProperties.Size = new System.Drawing.Size(268, 372);
            lstProperties.SmallImageList = imageList2;
            lstProperties.TabIndex = 2;
            lstProperties.UseCompatibleStateImageBehavior = false;
            lstProperties.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Property";
            columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Value";
            columnHeader3.Width = 140;
            // 
            // splitter1
            // 
            splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            splitter1.Location = new System.Drawing.Point(0, 146);
            splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(1093, 5);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // lstCacheFiles
            // 
            lstCacheFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lstCacheFiles.Dock = System.Windows.Forms.DockStyle.Top;
            lstCacheFiles.Location = new System.Drawing.Point(0, 0);
            lstCacheFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lstCacheFiles.MultiSelect = false;
            lstCacheFiles.Name = "lstCacheFiles";
            lstCacheFiles.Size = new System.Drawing.Size(1093, 146);
            lstCacheFiles.SmallImageList = imageList2;
            lstCacheFiles.TabIndex = 0;
            lstCacheFiles.UseCompatibleStateImageBehavior = false;
            lstCacheFiles.View = System.Windows.Forms.View.Details;
            lstCacheFiles.SelectedIndexChanged += lstCacheFiles_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Auto-detected thumbnail caches";
            columnHeader1.Width = 600;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(39, 17);
            lblStatus.Text = "Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1093, 741);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAsThumbs;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAsList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ListViewDblBuf listViewEntries;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Splitter splitter2;
        private ListViewDblBuf lstProperties;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Splitter splitter1;
        private ListViewDblBuf lstCacheFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

