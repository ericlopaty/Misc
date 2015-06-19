namespace StopWatch
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblElapsed
            // 
            this.lblElapsed.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.Location = new System.Drawing.Point(12, 9);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(181, 29);
            this.lblElapsed.TabIndex = 0;
            this.lblElapsed.Text = "0:00:00.00";
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(12, 60);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(75, 23);
            this.btnToggle.TabIndex = 1;
            this.btnToggle.Text = "Start";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnLap
            // 
            this.btnLap.Location = new System.Drawing.Point(93, 60);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(75, 23);
            this.btnLap.TabIndex = 2;
            this.btnLap.Text = "Lap";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(174, 60);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 95);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLap);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.lblElapsed);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StopWatch";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.Button btnReset;
    }
}

