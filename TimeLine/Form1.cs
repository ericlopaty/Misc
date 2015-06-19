using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeLine
{
    public partial class Form1 : Form
    {
        private StringBuilder timeLine = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            string tag;
            DateTime now = DateTime.Now;
            string title = now.ToString("h:mm:ss tt").ToLower();
            if (string.Compare(this.Text, title, true) != 0)
                this.Text = title;
            timeLine = new StringBuilder();
            DateTime instant = now;
            DateTime endOfDay = new DateTime(now.Year, now.Month, now.Day, 17, 1, 0);
            while (instant.CompareTo(endOfDay) <= 0)
            {
                tag = ".";
                if (instant.Minute % 15 == 0) tag = "!";
                if (instant.Minute == 0) tag = instant.ToString("h:mm");
                timeLine.Append(tag);
                instant = instant.AddMinutes(tag.Length);
            }
            if (string.Compare(timeLine.ToString(), lblTime.Text) != 0)
                lblTime.Text = timeLine.ToString();
            timer.Enabled = true;
        }
    }
}
