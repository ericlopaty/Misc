using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace pexp
{
    public partial class formProcessExplorer : Form
    {
        public formProcessExplorer()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formProcessExplorer_Load(object sender, EventArgs e)
        {
            //listView.Columns.Clear();
            //listView.Columns.Add("Process");
            //listView.Columns.Add("PID");
            //listView.Columns.Add("User Time");
            //listView.Columns.Add("System Time");
            //listView.Columns.Add("Total Time");
            //listView.Columns.Add("Responding");
            //listView.Columns.Add("Memory");
            //listView.Columns.Add("Threads");
            //listView.Columns.Add("Handles");
            //listView.Items.Clear();
            //Process[] processes = Process.GetProcesses();
            //foreach (Process p in processes)
            //{
            //    listView.Items.Add(new ListViewItem(p.ProcessName, p.Id, p.UserProcessorTime, p.PrivilegedProcessorTime, p.TotalProcessorTime, p.Responding, p.WorkingSet, p.Threads, p.HandleCount));
            //}
            listView.View = View.LargeIcon;
            menuSmallIcons.Checked = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblUpTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            if (listView.Items.Count > 0)
            {
            }
            else
            {
                foreach (Process p in processes)
                    listView.Items.Add(p.ProcessName);
            }
        }

        private void menuLargeIcons_Click(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;            
            menuLargeIcons.Checked = true;
            menuSmallIcons.Checked = false;
            menuList.Checked = false;
            menuDetails.Checked = false;
        }

        private void menuSmallIcons_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
            menuLargeIcons.Checked = false;
            menuSmallIcons.Checked = true;
            menuList.Checked = false;
            menuDetails.Checked = false;
        }

        private void menuList_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
            menuLargeIcons.Checked = false;
            menuSmallIcons.Checked = false;
            menuList.Checked = true;
            menuDetails.Checked = false;
        }

        private void menuDetails_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
            menuLargeIcons.Checked = false;
            menuSmallIcons.Checked = false;
            menuList.Checked = false;
            menuDetails.Checked = true;
        }
    }
}
