using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer t;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            t = new Timer();
            t.Elapsed += new ElapsedEventHandler(OnTimer);
            t.Interval = 1000;
            t.Enabled = true;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            StreamWriter file = File.AppendText("c:\\temp\\serviceoutput.txt");
            file.WriteLine(Environment.CurrentDirectory);
            file.Flush();
            file.Close();
            file.Dispose();
            Environment.CurrentDirectory = "c:\\temp";
        }

        protected override void OnStop()
        {
            t.Enabled = false;
            t.Close();
            t.Dispose();
        }
    }
}
