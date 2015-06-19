namespace BrainDump
{
    partial class FormMain
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
            this.btnTimers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTimers
            // 
            this.btnTimers.Location = new System.Drawing.Point(13, 13);
            this.btnTimers.Name = "btnTimers";
            this.btnTimers.Size = new System.Drawing.Size(75, 23);
            this.btnTimers.TabIndex = 0;
            this.btnTimers.Text = "Timers";
            this.btnTimers.UseVisualStyleBackColor = true;
            this.btnTimers.Click += new System.EventHandler(this.btnTimers_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 274);
            this.Controls.Add(this.btnTimers);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTimers;
    }
}

