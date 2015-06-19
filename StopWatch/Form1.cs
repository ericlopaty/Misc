using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        private bool lap = false;
        private DateTime startTime;
        private double totalSeconds = 0;
        private DateTime lapTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            btnToggle.Text = timer.Enabled ? "Stop" : "Start";
            if (timer.Enabled)
                startTime = DateTime.Now;
            else
                totalSeconds += DateTime.Now.Subtract(startTime).TotalSeconds;
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            lap = !lap;
            if (lap)
                lapTime = DateTime.Now;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            lap = false;
            lblElapsed.Text = "0:00:00.00";
            totalSeconds = 0;
            btnToggle.Text = "Start";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!lap)
            {
                double elapsed = DateTime.Now.Subtract(startTime).TotalSeconds + totalSeconds;
                int hours = (int)(elapsed / 3600);
                elapsed -= (hours * 3600);
                int minutes = (int)(elapsed / 60);
                elapsed -= (minutes * 60);
                double seconds = elapsed;
                lblElapsed.Text = string.Format("{0:0}:{1,2:00}:{2,5:00.00}", hours, minutes, seconds);
            }
            if (lap && DateTime.Now.Subtract(lapTime).TotalSeconds > 10.0)
                lap = false;
        }
    }
}
