namespace Compare
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.container = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewIdentical = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewLeftOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRightOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDifferent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lblLeft = new System.Windows.Forms.ToolStripLabel();
            this.tbLeft = new System.Windows.Forms.ToolStripTextBox();
            this.btnLeftSelect = new System.Windows.Forms.ToolStripButton();
            this.lblRight = new System.Windows.Forms.ToolStripLabel();
            this.tbRight = new System.Windows.Forms.ToolStripTextBox();
            this.btnRightSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.container.BottomToolStripPanel.SuspendLayout();
            this.container.ContentPanel.SuspendLayout();
            this.container.TopToolStripPanel.SuspendLayout();
            this.container.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            // 
            // container.BottomToolStripPanel
            // 
            this.container.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // container.ContentPanel
            // 
            this.container.ContentPanel.Controls.Add(this.listView);
            this.container.ContentPanel.Size = new System.Drawing.Size(770, 337);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(770, 383);
            this.container.TabIndex = 2;
            this.container.Text = "toolStripContainer1";
            // 
            // container.TopToolStripPanel
            // 
            this.container.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.container.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progress,
            this.statusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(770, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(350, 17);
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(300, 16);
            // 
            // statusLabelVersion
            // 
            this.statusLabelVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusLabelVersion.Name = "statusLabelVersion";
            this.statusLabelVersion.Size = new System.Drawing.Size(103, 17);
            this.statusLabelVersion.Spring = true;
            this.statusLabelVersion.Text = "Version: ";
            this.statusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(770, 337);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.viewToolStripMenuItem,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(770, 24);
            this.menuStrip.TabIndex = 2;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCompare,
            this.menuCancel,
            this.menuSynch,
            this.menuRefresh,
            this.toolStripSeparator1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // menuCompare
            // 
            this.menuCompare.Name = "menuCompare";
            this.menuCompare.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuCompare.Size = new System.Drawing.Size(182, 22);
            this.menuCompare.Text = "&Compare...";
            this.menuCompare.Click += new System.EventHandler(this.menuCompare_Click);
            // 
            // menuCancel
            // 
            this.menuCancel.Enabled = false;
            this.menuCancel.Name = "menuCancel";
            this.menuCancel.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.menuCancel.Size = new System.Drawing.Size(182, 22);
            this.menuCancel.Text = "Ca&ncel Compare";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // menuSynch
            // 
            this.menuSynch.Enabled = false;
            this.menuSynch.Name = "menuSynch";
            this.menuSynch.Size = new System.Drawing.Size(182, 22);
            this.menuSynch.Text = "&Synch Selected";
            // 
            // menuRefresh
            // 
            this.menuRefresh.Enabled = false;
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuRefresh.Size = new System.Drawing.Size(182, 22);
            this.menuRefresh.Text = "&Refresh";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuExit.Size = new System.Drawing.Size(182, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowAll,
            this.toolStripSeparator3,
            this.menuViewIdentical,
            this.menuViewLeftOnly,
            this.menuViewRightOnly,
            this.menuViewDifferent,
            this.toolStripSeparator4,
            this.menuViewFiles,
            this.toolStripSeparator5,
            this.menuConfigure});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // menuShowAll
            // 
            this.menuShowAll.Checked = true;
            this.menuShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuShowAll.Name = "menuShowAll";
            this.menuShowAll.Size = new System.Drawing.Size(144, 22);
            this.menuShowAll.Text = "Show &All";
            this.menuShowAll.Click += new System.EventHandler(this.menuView_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // menuViewIdentical
            // 
            this.menuViewIdentical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuViewIdentical.Name = "menuViewIdentical";
            this.menuViewIdentical.Size = new System.Drawing.Size(144, 22);
            this.menuViewIdentical.Text = "&Identical";
            this.menuViewIdentical.ToolTipText = "Contents are identical";
            this.menuViewIdentical.Click += new System.EventHandler(this.menuView_Click);
            // 
            // menuViewLeftOnly
            // 
            this.menuViewLeftOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuViewLeftOnly.Name = "menuViewLeftOnly";
            this.menuViewLeftOnly.Size = new System.Drawing.Size(144, 22);
            this.menuViewLeftOnly.Text = "&Left Only";
            this.menuViewLeftOnly.ToolTipText = "Only exists on the left.";
            this.menuViewLeftOnly.Click += new System.EventHandler(this.menuView_Click);
            // 
            // menuViewRightOnly
            // 
            this.menuViewRightOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuViewRightOnly.Name = "menuViewRightOnly";
            this.menuViewRightOnly.Size = new System.Drawing.Size(144, 22);
            this.menuViewRightOnly.Text = "&Right Only";
            this.menuViewRightOnly.ToolTipText = "Only exists on the right.";
            this.menuViewRightOnly.Click += new System.EventHandler(this.menuView_Click);
            // 
            // menuViewDifferent
            // 
            this.menuViewDifferent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuViewDifferent.Name = "menuViewDifferent";
            this.menuViewDifferent.Size = new System.Drawing.Size(144, 22);
            this.menuViewDifferent.Text = "&Different";
            this.menuViewDifferent.ToolTipText = "Contents differ.";
            this.menuViewDifferent.Click += new System.EventHandler(this.menuView_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // menuViewFiles
            // 
            this.menuViewFiles.Name = "menuViewFiles";
            this.menuViewFiles.Size = new System.Drawing.Size(144, 22);
            this.menuViewFiles.Text = "&View File(s)";
            this.menuViewFiles.Click += new System.EventHandler(this.menuViewFiles_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(141, 6);
            // 
            // menuConfigure
            // 
            this.menuConfigure.Name = "menuConfigure";
            this.menuConfigure.Size = new System.Drawing.Size(144, 22);
            this.menuConfigure.Text = "&Configure...";
            this.menuConfigure.Click += new System.EventHandler(this.menuConfigure_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout,
            this.testToolStripMenuItem});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(40, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(126, 22);
            this.menuAbout.Text = "&About...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLeft,
            this.tbLeft,
            this.btnLeftSelect,
            this.lblRight,
            this.tbRight,
            this.btnRightSelect,
            this.toolStripSeparator2,
            this.btnRefresh});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(802, 25);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Visible = false;
            // 
            // lblLeft
            // 
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(54, 22);
            this.lblLeft.Text = "Compare:";
            // 
            // tbLeft
            // 
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(300, 25);
            // 
            // btnLeftSelect
            // 
            this.btnLeftSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLeftSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftSelect.Image")));
            this.btnLeftSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLeftSelect.Name = "btnLeftSelect";
            this.btnLeftSelect.Size = new System.Drawing.Size(23, 22);
            this.btnLeftSelect.Text = "...";
            // 
            // lblRight
            // 
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(33, 22);
            this.lblRight.Text = "With:";
            // 
            // tbRight
            // 
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(300, 25);
            // 
            // btnRightSelect
            // 
            this.btnRightSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRightSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnRightSelect.Image")));
            this.btnRightSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRightSelect.Name = "btnRightSelect";
            this.btnRightSelect.Size = new System.Drawing.Size(23, 22);
            this.btnRightSelect.Text = "...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 22);
            this.btnRefresh.Text = "Refresh";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 383);
            this.Controls.Add(this.container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compare";
            this.Load += new System.EventHandler(this.FormCompare_Load);
            this.container.BottomToolStripPanel.ResumeLayout(false);
            this.container.BottomToolStripPanel.PerformLayout();
            this.container.ContentPanel.ResumeLayout(false);
            this.container.TopToolStripPanel.ResumeLayout(false);
            this.container.TopToolStripPanel.PerformLayout();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer container;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuCompare;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuSynch;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuViewIdentical;
        private System.Windows.Forms.ToolStripMenuItem menuViewLeftOnly;
        private System.Windows.Forms.ToolStripMenuItem menuViewRightOnly;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lblLeft;
        private System.Windows.Forms.ToolStripTextBox tbLeft;
        private System.Windows.Forms.ToolStripButton btnLeftSelect;
        private System.Windows.Forms.ToolStripLabel lblRight;
        private System.Windows.Forms.ToolStripTextBox tbRight;
        private System.Windows.Forms.ToolStripButton btnRightSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuCancel;
        private System.Windows.Forms.ToolStripMenuItem menuViewDifferent;
        private System.Windows.Forms.ToolStripMenuItem menuShowAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuViewFiles;
        private System.Windows.Forms.ToolStripMenuItem menuConfigure;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelVersion;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;

    }
}

