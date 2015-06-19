using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eod
{
  public partial class FormMain : Form
  {
    int color=0;

    public FormMain()
    {
      InitializeComponent();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      DateTime startOfDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
      double progress = DateTime.Now.Subtract(startOfDay).TotalSeconds;
      if (progress < 0) progress = 0;
      if (progress > 36000) progress = 36000;
      int newColor = (int)(progress / 36000 * 255);
      if (newColor > color)
        PaintIt(1);
      if (newColor < color)
        PaintIt(-1);
    }

    private void PaintIt(int delta)
    {
      Graphics gc;
      color += delta;
      gc = panel.CreateGraphics();
      this.Text = color.ToString();
      try
      {
        int red = 255 - color;
        int green = color;
        int blue = 0;
        gc.Clear(Color.FromArgb(red, green, blue));
      }
      catch
      {
      }
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
      PaintIt(0);
    }
  }
}