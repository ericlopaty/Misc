using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ExampleTray
{
    public partial class FormDisplay : Form
    {
        public FormDisplay()
        {
            InitializeComponent();
            eventLog.Source = Application.ProductName;
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            Program.StartService();
        }

        private void menuPause_Click(object sender, EventArgs e)
        {
            Program.PauseService();
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            Program.StopService();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Program.StopService();
            Program.KeepRunning = false;
            this.Close();
        }

        private void FormDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.displayForm = null;
        }

        private void FormDisplay_Load(object sender, EventArgs e)
        {
        }

        private string FormatEventLogEntry(EventLogEntry e)
        {
            return string.Format("[{0}] {1,-12} ({2}/{3}) {4}",
                e.TimeGenerated, e.EntryType, e.CategoryNumber, e.InstanceId, e.Message);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            lbEntries.Items.Clear();
            foreach (EventLogEntry entry in eventLog.Entries)
                if (entry.Source == Application.ProductName)
                    lbEntries.Items.Insert(0, FormatEventLogEntry(entry));
        }

        private void eventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            if (e.Entry.Source == Application.ProductName)
                lbEntries.Items.Insert(0, FormatEventLogEntry(e.Entry));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eventLog.Clear();
        }
    }
}
