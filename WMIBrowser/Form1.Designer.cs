namespace WMIBrowser
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbClassList = new System.Windows.Forms.ListBox();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.tbNameSpaceValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbClassList
            // 
            this.lbClassList.FormattingEnabled = true;
            this.lbClassList.Location = new System.Drawing.Point(214, 12);
            this.lbClassList.Name = "lbClassList";
            this.lbClassList.Size = new System.Drawing.Size(215, 303);
            this.lbClassList.TabIndex = 1;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(12, 338);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(35, 13);
            this.lblStatusValue.TabIndex = 2;
            this.lblStatusValue.Text = "label1";
            // 
            // tbNameSpaceValue
            // 
            this.tbNameSpaceValue.Location = new System.Drawing.Point(15, 42);
            this.tbNameSpaceValue.Name = "tbNameSpaceValue";
            this.tbNameSpaceValue.Size = new System.Drawing.Size(158, 20);
            this.tbNameSpaceValue.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 406);
            this.Controls.Add(this.tbNameSpaceValue);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.lbClassList);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "WMI Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbClassList;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.TextBox tbNameSpaceValue;
    }
}

