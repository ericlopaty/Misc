namespace stuff
{
    partial class Main
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblLost = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lbSchedule = new System.Windows.Forms.ListBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEditEvents = new System.Windows.Forms.Button();
            this.listEvents = new System.Windows.Forms.ListView();
            this.colEvent = new System.Windows.Forms.ColumnHeader();
            this.colDays = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabAlmanac = new System.Windows.Forms.TabPage();
            this.timerWeight = new System.Windows.Forms.Timer(this.components);
            this.timerEvents = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabAlmanac);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 273);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblDays);
            this.tabPage1.Controls.Add(this.lblLost);
            this.tabPage1.Controls.Add(this.lblWeight);
            this.tabPage1.Controls.Add(this.lbSchedule);
            this.tabPage1.Controls.Add(this.progress);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(436, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Weight";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Days:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Lost:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Weight:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDays
            // 
            this.lblDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(71, 63);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(68, 24);
            this.lblDays.TabIndex = 23;
            this.lblDays.Text = "999.99999";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLost
            // 
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLost.Location = new System.Drawing.Point(71, 39);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(68, 20);
            this.lblLost.TabIndex = 22;
            this.lblLost.Text = "99.99999";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWeight
            // 
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(71, 13);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(68, 20);
            this.lblWeight.TabIndex = 21;
            this.lblWeight.Text = "999.99999";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSchedule
            // 
            this.lbSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSchedule.BackColor = System.Drawing.SystemColors.Control;
            this.lbSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSchedule.ColumnWidth = 100;
            this.lbSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSchedule.FormattingEnabled = true;
            this.lbSchedule.Location = new System.Drawing.Point(8, 103);
            this.lbSchedule.MultiColumn = true;
            this.lbSchedule.Name = "lbSchedule";
            this.lbSchedule.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbSchedule.Size = new System.Drawing.Size(420, 130);
            this.lbSchedule.TabIndex = 20;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(143, 13);
            this.progress.Maximum = 256;
            this.progress.Minimum = 180;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(285, 20);
            this.progress.Step = 1;
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 19;
            this.progress.Value = 256;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditEvents);
            this.tabPage2.Controls.Add(this.listEvents);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(436, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Countdown";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditEvents
            // 
            this.btnEditEvents.AutoSize = true;
            this.btnEditEvents.Location = new System.Drawing.Point(9, 216);
            this.btnEditEvents.Name = "btnEditEvents";
            this.btnEditEvents.Size = new System.Drawing.Size(80, 23);
            this.btnEditEvents.TabIndex = 1;
            this.btnEditEvents.Text = "Edit Events...";
            this.btnEditEvents.UseVisualStyleBackColor = true;
            this.btnEditEvents.Click += new System.EventHandler(this.btnEditEvents_Click);
            // 
            // listEvents
            // 
            this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEvent,
            this.colDays});
            this.listEvents.Location = new System.Drawing.Point(8, 6);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(420, 204);
            this.listEvents.TabIndex = 0;
            this.listEvents.UseCompatibleStateImageBehavior = false;
            this.listEvents.View = System.Windows.Forms.View.Details;
            // 
            // colEvent
            // 
            this.colEvent.Text = "Event";
            this.colEvent.Width = 200;
            // 
            // colDays
            // 
            this.colDays.Text = "Days";
            this.colDays.Width = 75;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(436, 247);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Day";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabAlmanac
            // 
            this.tabAlmanac.Location = new System.Drawing.Point(4, 22);
            this.tabAlmanac.Name = "tabAlmanac";
            this.tabAlmanac.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlmanac.Size = new System.Drawing.Size(436, 247);
            this.tabAlmanac.TabIndex = 3;
            this.tabAlmanac.Text = "Almanac";
            this.tabAlmanac.UseVisualStyleBackColor = true;
            // 
            // timerEvents
            // 
            this.timerEvents.Enabled = true;
            this.timerEvents.Interval = 60000;
            this.timerEvents.Tick += new System.EventHandler(this.timerEvents_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 273);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.Text = "Stuff";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnEditEvents;
        private System.Windows.Forms.ListView listEvents;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.ColumnHeader colDays;
        private System.Windows.Forms.TabPage tabAlmanac;
        private System.Windows.Forms.Timer timerWeight;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblLost;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.ListBox lbSchedule;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Timer timerEvents;
    }
}

