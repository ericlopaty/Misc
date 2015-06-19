using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;

namespace ExampleService
{
    public partial class ServiceTimer : ServiceBase
    {
        private Timer timer;

        public ServiceTimer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timer = new Timer();
                timer.Elapsed += new ElapsedEventHandler(OnTimer);
                timer.Interval = 5000;
                timer.Enabled = true;
            }
            catch 
            {
            }
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = File.AppendText("c:\\temp\\ExampleService.log"))
                {
                    writer.WriteLine("[{0}] {1}",
                        DateTime.Now.ToString(), "Alive and well");
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception x)
            {
                using (StreamWriter writer=File.AppendText("c:\\temp\\ExampleServiceError.log"))
                {
                    writer.WriteLine(x.Message);
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        protected override void OnStop()
        {
            try
            {
                timer.Enabled = false;
                timer.Close();
                timer.Dispose();
            }
            catch 
            {
            }
        }
    }
}
