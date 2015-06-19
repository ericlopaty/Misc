using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace elapsed
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      try
      {
        DateTime target = DateTime.Parse(tbTarget.Text);
        TimeSpan span = DateTime.Now.Subtract(target);
        string caption = "unknown format";
        switch (cbFormat.Text.ToLower()[0])
        {
          case 's':
            caption = string.Format("{0:#,##0}", Math.Abs(span.TotalSeconds));
            break;
          case 'm':
            caption = string.Format("{0:#,##0.00}", Math.Abs(span.TotalMinutes));
            break;
          case 'h':
            caption = string.Format("{0:#,##0.0000}", Math.Abs(span.TotalHours));
            break;
          case 'd':
            caption = string.Format("{0:#,##0.00000}", Math.Abs(span.TotalDays));
            break;
        }
        if (string.Compare(this.Text, caption, true) != 0)
          this.Text = caption;
      }
      catch
      {
      }
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      tbTarget.Text = (string)Application.UserAppDataRegistry.GetValue("target", "");
      cbFormat.Text = (string)Application.UserAppDataRegistry.GetValue("format", "seconds");
    }

    private void tbTarget_Leave(object sender, EventArgs e)
    {
      Application.UserAppDataRegistry.SetValue("target", tbTarget.Text);
    }

    private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
      Application.UserAppDataRegistry.SetValue("format", cbFormat.Text);
    }
  }
}
