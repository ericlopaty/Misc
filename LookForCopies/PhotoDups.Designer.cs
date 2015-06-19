namespace PhotoDups
{
    partial class PhotoDups
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
            this.btnAddPath = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureOne = new System.Windows.Forms.PictureBox();
            this.pictureTwo = new System.Windows.Forms.PictureBox();
            this.listDups = new System.Windows.Forms.ListBox();
            this.btnRemove1 = new System.Windows.Forms.Button();
            this.btnRemove2 = new System.Windows.Forms.Button();
            this.tbOne = new System.Windows.Forms.TextBox();
            this.tbTwo = new System.Windows.Forms.TextBox();
            this.btnClearPaths = new System.Windows.Forms.Button();
            this.lstPaths = new System.Windows.Forms.ListBox();
            this.btnScanFiles = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTwo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(13, 13);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddPath.TabIndex = 0;
            this.btnAddPath.Text = "Add Path...";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // pictureOne
            // 
            this.pictureOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureOne.Location = new System.Drawing.Point(16, 299);
            this.pictureOne.Name = "pictureOne";
            this.pictureOne.Size = new System.Drawing.Size(400, 300);
            this.pictureOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOne.TabIndex = 2;
            this.pictureOne.TabStop = false;
            // 
            // pictureTwo
            // 
            this.pictureTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureTwo.Location = new System.Drawing.Point(422, 299);
            this.pictureTwo.Name = "pictureTwo";
            this.pictureTwo.Size = new System.Drawing.Size(400, 300);
            this.pictureTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTwo.TabIndex = 3;
            this.pictureTwo.TabStop = false;
            // 
            // listDups
            // 
            this.listDups.FormattingEnabled = true;
            this.listDups.Location = new System.Drawing.Point(13, 101);
            this.listDups.Name = "listDups";
            this.listDups.Size = new System.Drawing.Size(695, 160);
            this.listDups.TabIndex = 4;
            this.listDups.SelectedIndexChanged += new System.EventHandler(this.listDups_SelectedIndexChanged);
            this.listDups.Click += new System.EventHandler(this.listDups_Click);
            // 
            // btnRemove1
            // 
            this.btnRemove1.Location = new System.Drawing.Point(16, 270);
            this.btnRemove1.Name = "btnRemove1";
            this.btnRemove1.Size = new System.Drawing.Size(75, 23);
            this.btnRemove1.TabIndex = 6;
            this.btnRemove1.Text = "Remove";
            this.btnRemove1.UseVisualStyleBackColor = true;
            this.btnRemove1.Click += new System.EventHandler(this.btnRemove1_Click);
            // 
            // btnRemove2
            // 
            this.btnRemove2.Location = new System.Drawing.Point(422, 270);
            this.btnRemove2.Name = "btnRemove2";
            this.btnRemove2.Size = new System.Drawing.Size(75, 23);
            this.btnRemove2.TabIndex = 7;
            this.btnRemove2.Text = "Remove";
            this.btnRemove2.UseVisualStyleBackColor = true;
            this.btnRemove2.Click += new System.EventHandler(this.btnRemove2_Click);
            // 
            // tbOne
            // 
            this.tbOne.Location = new System.Drawing.Point(98, 273);
            this.tbOne.Name = "tbOne";
            this.tbOne.Size = new System.Drawing.Size(318, 20);
            this.tbOne.TabIndex = 8;
            // 
            // tbTwo
            // 
            this.tbTwo.Location = new System.Drawing.Point(504, 272);
            this.tbTwo.Name = "tbTwo";
            this.tbTwo.Size = new System.Drawing.Size(318, 20);
            this.tbTwo.TabIndex = 9;
            // 
            // btnClearPaths
            // 
            this.btnClearPaths.Location = new System.Drawing.Point(13, 42);
            this.btnClearPaths.Name = "btnClearPaths";
            this.btnClearPaths.Size = new System.Drawing.Size(75, 23);
            this.btnClearPaths.TabIndex = 10;
            this.btnClearPaths.Text = "Clear Paths";
            this.btnClearPaths.UseVisualStyleBackColor = true;
            this.btnClearPaths.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // lstPaths
            // 
            this.lstPaths.FormattingEnabled = true;
            this.lstPaths.Location = new System.Drawing.Point(104, 13);
            this.lstPaths.Name = "lstPaths";
            this.lstPaths.Size = new System.Drawing.Size(372, 82);
            this.lstPaths.TabIndex = 11;
            // 
            // btnScanFiles
            // 
            this.btnScanFiles.Location = new System.Drawing.Point(13, 72);
            this.btnScanFiles.Name = "btnScanFiles";
            this.btnScanFiles.Size = new System.Drawing.Size(75, 23);
            this.btnScanFiles.TabIndex = 12;
            this.btnScanFiles.Text = "Scan Files";
            this.btnScanFiles.UseVisualStyleBackColor = true;
            this.btnScanFiles.Click += new System.EventHandler(this.btnScanFiles_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 17);
            // 
            // PhotoDups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 642);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnScanFiles);
            this.Controls.Add(this.lstPaths);
            this.Controls.Add(this.btnClearPaths);
            this.Controls.Add(this.tbTwo);
            this.Controls.Add(this.tbOne);
            this.Controls.Add(this.btnRemove2);
            this.Controls.Add(this.btnRemove1);
            this.Controls.Add(this.listDups);
            this.Controls.Add(this.pictureTwo);
            this.Controls.Add(this.pictureOne);
            this.Controls.Add(this.btnAddPath);
            this.MaximizeBox = false;
            this.Name = "PhotoDups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Look for Copies";
            ((System.ComponentModel.ISupportInitialize)(this.pictureOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTwo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.PictureBox pictureOne;
        private System.Windows.Forms.PictureBox pictureTwo;
        private System.Windows.Forms.ListBox listDups;
        private System.Windows.Forms.Button btnRemove1;
        private System.Windows.Forms.Button btnRemove2;
        private System.Windows.Forms.TextBox tbOne;
        private System.Windows.Forms.TextBox tbTwo;
        private System.Windows.Forms.Button btnClearPaths;
        private System.Windows.Forms.ListBox lstPaths;
        private System.Windows.Forms.Button btnScanFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

