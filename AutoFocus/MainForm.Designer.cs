namespace AutoFocus
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
            this.rtbTasks = new System.Windows.Forms.RichTextBox();
            this.btnReEnter = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnDismiss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbTasks
            // 
            this.rtbTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTasks.Location = new System.Drawing.Point(12, 12);
            this.rtbTasks.Name = "rtbTasks";
            this.rtbTasks.Size = new System.Drawing.Size(610, 323);
            this.rtbTasks.TabIndex = 0;
            this.rtbTasks.Text = "";
            this.rtbTasks.TextChanged += new System.EventHandler(this.rtbTasks_TextChanged);
            // 
            // btnReEnter
            // 
            this.btnReEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReEnter.Location = new System.Drawing.Point(12, 341);
            this.btnReEnter.Name = "btnReEnter";
            this.btnReEnter.Size = new System.Drawing.Size(100, 23);
            this.btnReEnter.TabIndex = 1;
            this.btnReEnter.Text = "&Re-Enter";
            this.btnReEnter.UseVisualStyleBackColor = true;
            this.btnReEnter.Click += new System.EventHandler(this.btnReEnter_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinished.Location = new System.Drawing.Point(118, 341);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(100, 23);
            this.btnFinished.TabIndex = 2;
            this.btnFinished.Text = "&Finished";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnDismiss
            // 
            this.btnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDismiss.Location = new System.Drawing.Point(224, 341);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(100, 23);
            this.btnDismiss.TabIndex = 3;
            this.btnDismiss.Text = "&Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = true;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 370);
            this.Controls.Add(this.btnDismiss);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnReEnter);
            this.Controls.Add(this.rtbTasks);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoFocus";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTasks;
        private System.Windows.Forms.Button btnReEnter;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnDismiss;
    }
}

