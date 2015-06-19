namespace rpn
{
    partial class formRPN
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
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbT = new System.Windows.Forms.TextBox();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbX
            // 
            this.tbX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbX.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbX.Location = new System.Drawing.Point(12, 108);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(207, 26);
            this.tbX.TabIndex = 4;
            this.tbX.Text = "99,999,999.9999";
            this.tbX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            this.tbX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbX_KeyDown);
            this.tbX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbX_KeyPress);
            this.tbX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbX_KeyUp);
            // 
            // tbT
            // 
            this.tbT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbT.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbT.Location = new System.Drawing.Point(12, 12);
            this.tbT.Name = "tbT";
            this.tbT.Size = new System.Drawing.Size(207, 26);
            this.tbT.TabIndex = 6;
            this.tbT.Text = "99,999,999.9999";
            this.tbT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbZ
            // 
            this.tbZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbZ.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZ.Location = new System.Drawing.Point(12, 44);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(207, 26);
            this.tbZ.TabIndex = 7;
            this.tbZ.Text = "99,999,999.9999";
            this.tbZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbY
            // 
            this.tbY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbY.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbY.Location = new System.Drawing.Point(12, 76);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(207, 26);
            this.tbY.TabIndex = 8;
            this.tbY.Text = "99,999,999.9999";
            this.tbY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // formRPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 143);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.tbT);
            this.Controls.Add(this.tbX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "formRPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPN";
            this.Load += new System.EventHandler(this.formRPN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formRPN_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formRPN_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbT;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.TextBox tbY;


    }
}

