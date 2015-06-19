namespace elapsed
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
      this.components = new System.ComponentModel.Container();
      this.tbTarget = new System.Windows.Forms.TextBox();
      this.cbFormat = new System.Windows.Forms.ComboBox();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // tbTarget
      // 
      this.tbTarget.Location = new System.Drawing.Point(13, 13);
      this.tbTarget.Name = "tbTarget";
      this.tbTarget.Size = new System.Drawing.Size(168, 20);
      this.tbTarget.TabIndex = 0;
      this.tbTarget.Leave += new System.EventHandler(this.tbTarget_Leave);
      // 
      // cbFormat
      // 
      this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFormat.FormattingEnabled = true;
      this.cbFormat.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days"});
      this.cbFormat.Location = new System.Drawing.Point(187, 13);
      this.cbFormat.Name = "cbFormat";
      this.cbFormat.Size = new System.Drawing.Size(121, 21);
      this.cbFormat.TabIndex = 1;
      this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(320, 89);
      this.Controls.Add(this.cbFormat);
      this.Controls.Add(this.tbTarget);
      this.MaximizeBox = false;
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Elapsed";
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbTarget;
    private System.Windows.Forms.ComboBox cbFormat;
    private System.Windows.Forms.Timer timer;
  }
}

