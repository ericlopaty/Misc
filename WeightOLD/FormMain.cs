using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Weight
{
    public partial class FormMain : Form
    {
        private double factor = 2.0 / (86400 * 7);
        private string ruler = "----+---200---+---210---+---220---+---230---+---240---+---250---+---260\n";
        private DateTime endDate;
        private double target = 190.0;
        private DateTime now;

        public FormMain()
        {
            InitializeComponent();
        }

        private int RoundUp(double t)
        {
            return (int)Math.Ceiling(t);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            endDate = Program.StartTime.AddSeconds((Program.StartWeight - target) / factor);
            lblProgress.Text = "";
            now = DateTime.Now;
            timer.Enabled = true;
        }

        private void UpdateTitle(double weight)
        {
            string display = string.Format("{0:0.0}", weight);
            if (string.Compare(this.Text, display) != 0)
                this.Text = display;
        }

        private void UpdateProgress(string progress)
        {
            if (string.Compare(progress, lblProgress.Text) != 0)
                lblProgress.Text = progress;
        }

        private string FormatSeconds(int seconds)
        {
            int d = (seconds / 86400);
            seconds -= (d * 86400);
            int h = seconds / 3600;
            seconds -= (h * 3600);
            int m = seconds / 60;
            seconds -= (m * 60);
            int s = seconds;
            if (d > 0) return string.Format("{0:0}:{1,2:00}:{2,2:00}:{3,2:00}", d, h, m, s);
            if (h > 0) return string.Format("{0:0}:{1,2:00}:{2,2:00}", h, m, s);
            if (m > 0) return string.Format("{0:0}:{1,2:00}", m, s);
            if (s > 0) return string.Format("{0:0}", s);
            return "";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Enabled = false;
                now = DateTime.Now;
                //now = now.AddSeconds(now.Second == 0 ? 180 : 1);
                double elapsed = now.Subtract(Program.StartTime).TotalSeconds;
                double weight = Math.Max(Program.StartWeight - (elapsed * factor), target);
                double remain = weight - target < 0 ? 0 : weight - target;
                double daysLeft = Math.Max(endDate.Subtract(now).TotalDays, 0);
                int secondsLeft = Math.Max(RoundUp(endDate.Subtract(now).TotalSeconds), 0);
                UpdateTitle(weight);
                StringBuilder progress = new StringBuilder();
                if (weight > target)
                {
                    progress.Append(ruler);
                    progress.Append("".PadRight((int)Math.Max(0, RoundUp(weight - target)), '#') + "\n");
                    int c = 0;
                    DateTime t = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    while (t.CompareTo(endDate) <= 0 && daysLeft > 0)
                    {
                        //if (c != 0 && t.Day == 1) progress.Append(".");
                        if (c != 0 && t.DayOfWeek == DayOfWeek.Monday) progress.Append(".");
                        progress.Append(t.ToString("MMM").ToLower()[0]);
                        t = t.AddDays(1);
                        c++;
                    }
                    progress.Append(string.Format("\n{0:0.00000}\n{1} - {2:#,###}", remain, FormatSeconds(secondsLeft),secondsLeft));
                }
                UpdateProgress(progress.ToString());
                timer.Enabled = (weight > target);
            }
            catch
            {
            }
        }
    }
}
