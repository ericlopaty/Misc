using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace BrainDump
{
    public partial class FormTimers : Form
    {
        private static System.Timers.Timer timer = null;

        public FormTimers()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                timer = new System.Timers.Timer(5000);
                timer.Elapsed += new ElapsedEventHandler(OnTimer);
                timer.AutoReset = false;
                timer.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void OnTimer(object sender, ElapsedEventArgs args)
        {
            MessageBox.Show("Timed Event");
        }

        private void FormTimers_Load(object sender, EventArgs e)
        {

        }

        private void FormTimers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer!=null)
            {
                timer.Close();
                timer.Dispose();
            }
        }
    }
}

