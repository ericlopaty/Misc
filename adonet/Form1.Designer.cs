namespace adonet
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
      this.button1 = new System.Windows.Forms.Button();
      this.lblMessage = new System.Windows.Forms.Label();
      this.lblState = new System.Windows.Forms.Label();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.lbMessages = new System.Windows.Forms.ListBox();
      this.btnClear = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // lblMessage
      // 
      this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessage.Location = new System.Drawing.Point(12, 405);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(296, 23);
      this.lblMessage.TabIndex = 1;
      // 
      // lblState
      // 
      this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblState.Location = new System.Drawing.Point(314, 405);
      this.lblState.Name = "lblState";
      this.lblState.Size = new System.Drawing.Size(296, 23);
      this.lblState.TabIndex = 3;
      // 
      // dataGrid
      // 
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Location = new System.Drawing.Point(12, 41);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(422, 343);
      this.dataGrid.TabIndex = 4;
      // 
      // lbMessages
      // 
      this.lbMessages.FormattingEnabled = true;
      this.lbMessages.Location = new System.Drawing.Point(440, 12);
      this.lbMessages.Name = "lbMessages";
      this.lbMessages.Size = new System.Drawing.Size(367, 316);
      this.lbMessages.TabIndex = 5;
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(732, 334);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 23);
      this.btnClear.TabIndex = 6;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(819, 437);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.lbMessages);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.lblState);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Label lblState;
    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.ListBox lbMessages;
    private System.Windows.Forms.Button btnClear;
  }
}

