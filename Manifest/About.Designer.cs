namespace Manifest
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.lblProductName = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			this.lblFileVersionTag = new System.Windows.Forms.Label();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.lblProductVersionTag = new System.Windows.Forms.Label();
			this.lblProductVersion = new System.Windows.Forms.Label();
			this.lblFileVersion = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.lblProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.lblCopyright, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.lblCompany, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.lblFileVersionTag, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.tbDescription, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.lblProductVersionTag, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.lblProductVersion, 2, 3);
			this.tableLayoutPanel.Controls.Add(this.lblFileVersion, 2, 4);
			this.tableLayoutPanel.Controls.Add(this.okButton, 2, 6);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 7;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
			this.tableLayoutPanel.TabIndex = 0;
			this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 7);
			this.logoPictureBox.Size = new System.Drawing.Size(131, 259);
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// lblProductName
			// 
			this.tableLayoutPanel.SetColumnSpan(this.lblProductName, 2);
			this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProductName.Location = new System.Drawing.Point(143, 0);
			this.lblProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblProductName.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(271, 17);
			this.lblProductName.TabIndex = 19;
			this.lblProductName.Text = "Product Name";
			this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCopyright
			// 
			this.tableLayoutPanel.SetColumnSpan(this.lblCopyright, 2);
			this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCopyright.Location = new System.Drawing.Point(143, 26);
			this.lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblCopyright.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(271, 17);
			this.lblCopyright.TabIndex = 0;
			this.lblCopyright.Text = "Copyright";
			this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCompany
			// 
			this.tableLayoutPanel.SetColumnSpan(this.lblCompany, 2);
			this.lblCompany.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCompany.Location = new System.Drawing.Point(143, 52);
			this.lblCompany.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblCompany.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(271, 17);
			this.lblCompany.TabIndex = 25;
			this.lblCompany.Text = "Company Name";
			this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFileVersionTag
			// 
			this.lblFileVersionTag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFileVersionTag.Location = new System.Drawing.Point(143, 104);
			this.lblFileVersionTag.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblFileVersionTag.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblFileVersionTag.Name = "lblFileVersionTag";
			this.lblFileVersionTag.Size = new System.Drawing.Size(95, 17);
			this.lblFileVersionTag.TabIndex = 22;
			this.lblFileVersionTag.Text = "File Version";
			this.lblFileVersionTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbDescription
			// 
			this.tableLayoutPanel.SetColumnSpan(this.tbDescription, 2);
			this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbDescription.Location = new System.Drawing.Point(143, 133);
			this.tbDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ReadOnly = true;
			this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbDescription.Size = new System.Drawing.Size(271, 100);
			this.tbDescription.TabIndex = 23;
			this.tbDescription.TabStop = false;
			this.tbDescription.Text = "Description";
			// 
			// lblProductVersionTag
			// 
			this.lblProductVersionTag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProductVersionTag.Location = new System.Drawing.Point(143, 78);
			this.lblProductVersionTag.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblProductVersionTag.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblProductVersionTag.Name = "lblProductVersionTag";
			this.lblProductVersionTag.Size = new System.Drawing.Size(95, 17);
			this.lblProductVersionTag.TabIndex = 21;
			this.lblProductVersionTag.Text = "Product Version";
			this.lblProductVersionTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblProductVersion
			// 
			this.lblProductVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProductVersion.Location = new System.Drawing.Point(247, 78);
			this.lblProductVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblProductVersion.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblProductVersion.Name = "lblProductVersion";
			this.lblProductVersion.Size = new System.Drawing.Size(167, 17);
			this.lblProductVersion.TabIndex = 26;
			this.lblProductVersion.Text = "Product Version";
			this.lblProductVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFileVersion
			// 
			this.lblFileVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFileVersion.Location = new System.Drawing.Point(247, 104);
			this.lblFileVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lblFileVersion.MaximumSize = new System.Drawing.Size(0, 17);
			this.lblFileVersion.Name = "lblFileVersion";
			this.lblFileVersion.Size = new System.Drawing.Size(167, 17);
			this.lblFileVersion.TabIndex = 27;
			this.lblFileVersion.Text = "File Version";
			this.lblFileVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(339, 239);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			// 
			// About
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 283);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblProductVersionTag;
        private System.Windows.Forms.Label lblFileVersionTag;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.Label lblFileVersion;
    }
}
