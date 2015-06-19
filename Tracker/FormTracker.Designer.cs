namespace Tracker
{
  partial class FormTracker
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
      this.lbSatellites = new System.Windows.Forms.ListBox();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.cboSource = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbSatellites
      // 
      this.lbSatellites.FormattingEnabled = true;
      this.lbSatellites.Location = new System.Drawing.Point(91, 37);
      this.lbSatellites.Name = "lbSatellites";
      this.lbSatellites.Size = new System.Drawing.Size(212, 225);
      this.lbSatellites.Sorted = true;
      this.lbSatellites.TabIndex = 0;
      this.lbSatellites.SelectedIndexChanged += new System.EventHandler(this.lbSatellites_SelectedIndexChanged);
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(394, 8);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 1;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDate,
            this.lblTime});
      this.statusStrip.Location = new System.Drawing.Point(0, 400);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(712, 22);
      this.statusStrip.TabIndex = 2;
      this.statusStrip.Text = "statusStrip1";
      // 
      // lblDate
      // 
      this.lblDate.AutoSize = false;
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(109, 17);
      // 
      // lblTime
      // 
      this.lblTime.AutoSize = false;
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(109, 17);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 1000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // cboSource
      // 
      this.cboSource.FormattingEnabled = true;
      this.cboSource.Items.AddRange(new object[] {
            "http://www.celestrak.com/NORAD/elements/stations.txt",
            "http://www.celestrak.com/NORAD/elements/visual.txt"});
      this.cboSource.Location = new System.Drawing.Point(91, 10);
      this.cboSource.Name = "cboSource";
      this.cboSource.Size = new System.Drawing.Size(297, 21);
      this.cboSource.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Elements File:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Satellites:";
      // 
      // FormTracker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 422);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cboSource);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.lbSatellites);
      this.Name = "FormTracker";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tracker";
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox lbSatellites;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblDate;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.ToolStripStatusLabel lblTime;
    private System.Windows.Forms.ComboBox cboSource;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

