namespace ExampleWin
{
    partial class FormDispatch
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLoadNames = new System.Windows.Forms.Button();
            this.btnLoadAccounts = new System.Windows.Forms.Button();
            this.btnDropTables = new System.Windows.Forms.Button();
            this.btnCreateTables = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGetId = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Data Bound Grid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "DataSet Updates";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLoadNames
            // 
            this.btnLoadNames.Location = new System.Drawing.Point(12, 12);
            this.btnLoadNames.Name = "btnLoadNames";
            this.btnLoadNames.Size = new System.Drawing.Size(120, 23);
            this.btnLoadNames.TabIndex = 2;
            this.btnLoadNames.Text = "Load Names";
            this.btnLoadNames.UseVisualStyleBackColor = true;
            this.btnLoadNames.Click += new System.EventHandler(this.btnLoadNames_Click);
            // 
            // btnLoadAccounts
            // 
            this.btnLoadAccounts.Location = new System.Drawing.Point(12, 41);
            this.btnLoadAccounts.Name = "btnLoadAccounts";
            this.btnLoadAccounts.Size = new System.Drawing.Size(120, 23);
            this.btnLoadAccounts.TabIndex = 3;
            this.btnLoadAccounts.Text = "Load Accounts";
            this.btnLoadAccounts.UseVisualStyleBackColor = true;
            this.btnLoadAccounts.Click += new System.EventHandler(this.btnLoadAccounts_Click);
            // 
            // btnDropTables
            // 
            this.btnDropTables.Location = new System.Drawing.Point(138, 12);
            this.btnDropTables.Name = "btnDropTables";
            this.btnDropTables.Size = new System.Drawing.Size(120, 23);
            this.btnDropTables.TabIndex = 4;
            this.btnDropTables.Text = "Drop Tables";
            this.btnDropTables.UseVisualStyleBackColor = true;
            this.btnDropTables.Click += new System.EventHandler(this.btnDropTables_Click);
            // 
            // btnCreateTables
            // 
            this.btnCreateTables.Location = new System.Drawing.Point(138, 41);
            this.btnCreateTables.Name = "btnCreateTables";
            this.btnCreateTables.Size = new System.Drawing.Size(120, 23);
            this.btnCreateTables.TabIndex = 5;
            this.btnCreateTables.Text = "Create Tables";
            this.btnCreateTables.UseVisualStyleBackColor = true;
            this.btnCreateTables.Click += new System.EventHandler(this.btnCreateTables_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 17);
            // 
            // btnGetId
            // 
            this.btnGetId.Location = new System.Drawing.Point(138, 70);
            this.btnGetId.Name = "btnGetId";
            this.btnGetId.Size = new System.Drawing.Size(120, 23);
            this.btnGetId.TabIndex = 7;
            this.btnGetId.Text = "Get ID";
            this.btnGetId.UseVisualStyleBackColor = true;
            this.btnGetId.Click += new System.EventHandler(this.btnGetId_Click);
            // 
            // FormDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btnGetId);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCreateTables);
            this.Controls.Add(this.btnDropTables);
            this.Controls.Add(this.btnLoadAccounts);
            this.Controls.Add(this.btnLoadNames);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormDispatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatch";
            this.Load += new System.EventHandler(this.FormDispatch_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLoadNames;
        private System.Windows.Forms.Button btnLoadAccounts;
        private System.Windows.Forms.Button btnDropTables;
        private System.Windows.Forms.Button btnCreateTables;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnGetId;
    }
}