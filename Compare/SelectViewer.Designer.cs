namespace Compare
{
    partial class SelectViewer
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
            this.tbViewer = new System.Windows.Forms.TextBox();
            this.btnSelectViewer = new System.Windows.Forms.Button();
            this.cbMultiple = new System.Windows.Forms.CheckBox();
            this.cbUseNotepad = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Viewer:";
            // 
            // tbViewer
            // 
            this.tbViewer.Location = new System.Drawing.Point(12, 29);
            this.tbViewer.Name = "tbViewer";
            this.tbViewer.Size = new System.Drawing.Size(298, 20);
            this.tbViewer.TabIndex = 1;
            // 
            // btnSelectViewer
            // 
            this.btnSelectViewer.AutoSize = true;
            this.btnSelectViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectViewer.Location = new System.Drawing.Point(316, 28);
            this.btnSelectViewer.Name = "btnSelectViewer";
            this.btnSelectViewer.Size = new System.Drawing.Size(26, 23);
            this.btnSelectViewer.TabIndex = 2;
            this.btnSelectViewer.Text = "...";
            this.btnSelectViewer.UseVisualStyleBackColor = true;
            this.btnSelectViewer.Click += new System.EventHandler(this.btnSelectViewer_Click);
            // 
            // cbMultiple
            // 
            this.cbMultiple.AutoSize = true;
            this.cbMultiple.Location = new System.Drawing.Point(12, 55);
            this.cbMultiple.Name = "cbMultiple";
            this.cbMultiple.Size = new System.Drawing.Size(124, 17);
            this.cbMultiple.TabIndex = 3;
            this.cbMultiple.Text = "Accepts multiple files";
            this.cbMultiple.UseVisualStyleBackColor = true;
            // 
            // cbUseNotepad
            // 
            this.cbUseNotepad.AutoSize = true;
            this.cbUseNotepad.Location = new System.Drawing.Point(12, 78);
            this.cbUseNotepad.Name = "cbUseNotepad";
            this.cbUseNotepad.Size = new System.Drawing.Size(203, 17);
            this.cbUseNotepad.TabIndex = 4;
            this.cbUseNotepad.Text = "Use Notepad (must be in user\'s  path)";
            this.cbUseNotepad.UseVisualStyleBackColor = true;
            this.cbUseNotepad.CheckedChanged += new System.EventHandler(this.cbUseNotepad_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SelectViewer
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 175);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbUseNotepad);
            this.Controls.Add(this.cbMultiple);
            this.Controls.Add(this.btnSelectViewer);
            this.Controls.Add(this.tbViewer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select File Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbViewer;
        private System.Windows.Forms.Button btnSelectViewer;
        private System.Windows.Forms.CheckBox cbMultiple;
        private System.Windows.Forms.CheckBox cbUseNotepad;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}