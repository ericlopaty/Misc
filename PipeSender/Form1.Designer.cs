namespace PipeSender
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
            this.lbToBeSent = new System.Windows.Forms.ListBox();
            this.btnPrepList = new System.Windows.Forms.Button();
            this.tbSendCount = new System.Windows.Forms.TextBox();
            this.lbReceipts = new System.Windows.Forms.ListBox();
            this.btnStartSending = new System.Windows.Forms.Button();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbToBeSent
            // 
            this.lbToBeSent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbToBeSent.FormattingEnabled = true;
            this.lbToBeSent.Location = new System.Drawing.Point(12, 12);
            this.lbToBeSent.Name = "lbToBeSent";
            this.lbToBeSent.Size = new System.Drawing.Size(423, 368);
            this.lbToBeSent.TabIndex = 0;
            // 
            // btnPrepList
            // 
            this.btnPrepList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrepList.Location = new System.Drawing.Point(118, 388);
            this.btnPrepList.Name = "btnPrepList";
            this.btnPrepList.Size = new System.Drawing.Size(75, 23);
            this.btnPrepList.TabIndex = 1;
            this.btnPrepList.Text = "PrepList";
            this.btnPrepList.UseVisualStyleBackColor = true;
            this.btnPrepList.Click += new System.EventHandler(this.btnPrepList_Click);
            // 
            // tbSendCount
            // 
            this.tbSendCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSendCount.Location = new System.Drawing.Point(12, 391);
            this.tbSendCount.Name = "tbSendCount";
            this.tbSendCount.Size = new System.Drawing.Size(100, 20);
            this.tbSendCount.TabIndex = 2;
            // 
            // lbReceipts
            // 
            this.lbReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReceipts.FormattingEnabled = true;
            this.lbReceipts.Location = new System.Drawing.Point(441, 12);
            this.lbReceipts.Name = "lbReceipts";
            this.lbReceipts.Size = new System.Drawing.Size(176, 368);
            this.lbReceipts.Sorted = true;
            this.lbReceipts.TabIndex = 3;
            // 
            // btnStartSending
            // 
            this.btnStartSending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartSending.Location = new System.Drawing.Point(199, 389);
            this.btnStartSending.Name = "btnStartSending";
            this.btnStartSending.Size = new System.Drawing.Size(94, 23);
            this.btnStartSending.TabIndex = 4;
            this.btnStartSending.Text = "Start Sending";
            this.btnStartSending.UseVisualStyleBackColor = true;
            this.btnStartSending.Click += new System.EventHandler(this.btnStartSending_Click);
            // 
            // tbReceived
            // 
            this.tbReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbReceived.Location = new System.Drawing.Point(441, 390);
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.Size = new System.Drawing.Size(100, 20);
            this.tbReceived.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 423);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.btnStartSending);
            this.Controls.Add(this.lbReceipts);
            this.Controls.Add(this.tbSendCount);
            this.Controls.Add(this.btnPrepList);
            this.Controls.Add(this.lbToBeSent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbToBeSent;
        private System.Windows.Forms.Button btnPrepList;
        private System.Windows.Forms.TextBox tbSendCount;
        private System.Windows.Forms.ListBox lbReceipts;
        private System.Windows.Forms.Button btnStartSending;
        private System.Windows.Forms.TextBox tbReceived;
    }
}

