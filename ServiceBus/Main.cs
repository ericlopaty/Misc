using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBus
{
    public partial class Main : Form
    {
        private enum State
        {
            Running, Stopped, Paused
        }

        public Main()
        {
            InitializeComponent();
            Global.Log = new Logger(this.lbLog, Logger.FilterLevel.Info);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StateChange(State.Running);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StateChange(State.Stopped);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            StateChange(State.Paused);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Global.Log.LogInfo("Bus", "Loaded");
            labelStatus.Text = "Stopped";
        }

        private void StateChange(State state)
        {
            switch (state)
            {
                case State.Running:
                    btnStart.Enabled = false;
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                    labelStatus.Text = "Running";
                    Global.Log.LogInfo("Bus", "Running");
                    break;
                case State.Stopped:
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    btnPause.Enabled = false;
                    labelStatus.Text = "Stopped";
                    Global.Log.LogInfo("Bus", "Stopped");
                    break;
                case State.Paused:
                    btnStart.Enabled = true;
                    btnStop.Enabled = true;
                    btnPause.Enabled = false;
                    labelStatus.Text = "Paused";
                    Global.Log.LogInfo("Bus", "Paused");
                    break;
            }
        }
    }
}
