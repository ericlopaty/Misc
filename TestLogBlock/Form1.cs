using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;

namespace TestLogBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogEvent_Click(object sender, EventArgs e)
        {
            LogEntry log = new LogEntry();
            log.EventId = 100;
            log.Message = "button pressed";
            //log.Categories.Add("UI Events");
            log.Severity = TraceEventType.Information;
            log.Priority = 5;
            Logger.Write(log);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogEntry log = new LogEntry();
            log.EventId = 9999;
            log.Message = "button pressed";
            log.Title = "a button event";
            log.Categories.Add("AppLog");
            log.Severity = TraceEventType.Verbose;
            log.Priority = 0;
            Logger.Write(log);
        }
    }
}
