namespace TIFFUtility
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSplitPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSplitPath = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnReadProperties = new System.Windows.Forms.Button();
            this.lbProperties = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TIFF File:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(69, 12);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(363, 20);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Text = "c:\\temp\\test.tif";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "tiff";
            this.openFileDialog.Filter = "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.AutoSize = true;
            this.btnChooseFile.Location = new System.Drawing.Point(438, 10);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(26, 23);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Split Path:";
            // 
            // tbSplitPath
            // 
            this.tbSplitPath.Location = new System.Drawing.Point(69, 38);
            this.tbSplitPath.Name = "tbSplitPath";
            this.tbSplitPath.Size = new System.Drawing.Size(363, 20);
            this.tbSplitPath.TabIndex = 4;
            this.tbSplitPath.Text = "c:\\temp";
            // 
            // btnSplitPath
            // 
            this.btnSplitPath.AutoSize = true;
            this.btnSplitPath.Location = new System.Drawing.Point(438, 36);
            this.btnSplitPath.Name = "btnSplitPath";
            this.btnSplitPath.Size = new System.Drawing.Size(26, 23);
            this.btnSplitPath.TabIndex = 5;
            this.btnSplitPath.Text = "...";
            this.btnSplitPath.UseVisualStyleBackColor = true;
            this.btnSplitPath.Click += new System.EventHandler(this.btnSplitPath_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(168, 64);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 7;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnReadProperties
            // 
            this.btnReadProperties.AutoSize = true;
            this.btnReadProperties.Location = new System.Drawing.Point(69, 64);
            this.btnReadProperties.Name = "btnReadProperties";
            this.btnReadProperties.Size = new System.Drawing.Size(93, 23);
            this.btnReadProperties.TabIndex = 8;
            this.btnReadProperties.Text = "Read Properties";
            this.btnReadProperties.UseVisualStyleBackColor = true;
            this.btnReadProperties.Click += new System.EventHandler(this.btnReadProperties_Click_1);
            // 
            // lbProperties
            // 
            this.lbProperties.FormattingEnabled = true;
            this.lbProperties.Location = new System.Drawing.Point(69, 93);
            this.lbProperties.Name = "lbProperties";
            this.lbProperties.Size = new System.Drawing.Size(363, 212);
            this.lbProperties.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 320);
            this.Controls.Add(this.lbProperties);
            this.Controls.Add(this.btnReadProperties);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnSplitPath);
            this.Controls.Add(this.tbSplitPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIFF Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSplitPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSplitPath;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnReadProperties;
        private System.Windows.Forms.ListBox lbProperties;
    }
}

