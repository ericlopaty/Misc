using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;
using System.IO;

namespace TrayApp
{
    public enum ServiceState
    {
        Running, Paused, Stopped, Error
    }

    public partial class FormTrayApp : Form
    {
        private const string APP_TITLE = "Basic System Tray Application";
        private const string APP_RUNNING = "Running Normally";
        private const string APP_PAUSED = "Paused";
        private const string APP_STOPPED = "Stopped";
        private const string APP_ERROR = "Error";

        private bool windowStateChange = false;

        public FormTrayApp()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basic System Tray Application", "About", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void  menuHide_Click(object sender, EventArgs e)
        {
            Program.HideWhenMinimized = !Program.HideWhenMinimized;
            menuHide.Checked = Program.HideWhenMinimized;
            Program.SaveSettings();
        }

        private void FormTrayApp_Load(object sender, EventArgs e)
        {
            menuHide.Checked = Program.HideWhenMinimized;
        }

        private void ServiceControl(string serviceTag)
        {
            Stream file;
            string iconFile="";
            if (string.Compare(serviceTag, "start", true)==0)
            {
                iconFile = "icons.servicerunning.ico";
                notifyIcon.Text = APP_RUNNING;
            }
            if (string.Compare(serviceTag, "pause", true) == 0)
            {
                iconFile = "icons.servicepaused.ico";
                notifyIcon.Text = APP_PAUSED;
            }
            if (string.Compare(serviceTag, "stop", true) == 0)
            {
                iconFile = "icons.servicestopped.ico";
                notifyIcon.Text = APP_STOPPED;
            }
            file = Program.Assembly.GetManifestResourceStream(
                string.Format("{0}.{1}", Application.ProductName, iconFile));
            notifyIcon.Icon = new Icon(file);
        }

        private void DisplayWindow()
        {
            //windowStateChange = true;
            //if (this.WindowState == FormWindowState.Minimized)
            //    this.WindowState = FormWindowState.Normal;
            //this.Visible = true;
            //this.Activate();
            //windowStateChange = false;
            Program.statusForm = new FormStatus();
            Program.statusForm.Show();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DisplayWindow();
        }

        private void ServiceControl_Click(object sender, EventArgs e)
        {
            string  tag = (string)((sender as ToolStripMenuItem).Tag);
            ServiceControl(tag);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextOpen_Click(object sender, EventArgs e)
        {
            DisplayWindow();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
