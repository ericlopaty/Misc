namespace GetWindowText
{
    partial class FormGetWindowText
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
            this.tbHandle = new System.Windows.Forms.TextBox();
            this.btnGetWindowText = new System.Windows.Forms.Button();
            this.tbWindowText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbHandle
            // 
            this.tbHandle.Location = new System.Drawing.Point(12, 12);
            this.tbHandle.Name = "tbHandle";
            this.tbHandle.Size = new System.Drawing.Size(135, 20);
            this.tbHandle.TabIndex = 0;
            this.tbHandle.TextChanged += new System.EventHandler(this.tbHandle_TextChanged);
            this.tbHandle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHandle_KeyPress);
            // 
            // btnGetWindowText
            // 
            this.btnGetWindowText.Location = new System.Drawing.Point(153, 10);
            this.btnGetWindowText.Name = "btnGetWindowText";
            this.btnGetWindowText.Size = new System.Drawing.Size(97, 23);
            this.btnGetWindowText.TabIndex = 1;
            this.btnGetWindowText.Text = "GetWindowText";
            this.btnGetWindowText.UseVisualStyleBackColor = true;
            this.btnGetWindowText.Click += new System.EventHandler(this.btnGetWindowText_Click);
            // 
            // tbWindowText
            // 
            this.tbWindowText.Location = new System.Drawing.Point(12, 52);
            this.tbWindowText.Multiline = true;
            this.tbWindowText.Name = "tbWindowText";
            this.tbWindowText.ReadOnly = true;
            this.tbWindowText.Size = new System.Drawing.Size(448, 66);
            this.tbWindowText.TabIndex = 2;
            // 
            // FormGetWindowText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 130);
            this.Controls.Add(this.tbWindowText);
            this.Controls.Add(this.btnGetWindowText);
            this.Controls.Add(this.tbHandle);
            this.MaximizeBox = false;
            this.Name = "FormGetWindowText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetWindowText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHandle;
        private System.Windows.Forms.Button btnGetWindowText;
        private System.Windows.Forms.TextBox tbWindowText;
    }
}

