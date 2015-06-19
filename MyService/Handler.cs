using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Timers;
using System.Threading;

namespace MyService
{
    public partial class Handler : ServiceBase
    {
        private DateTime startTime;
        private DateTime lastHeartbeat;
        private string server;
        private string database;
        private int serviceInterval;
        private int heartbeatInterval;
        private int processedCount;
        private int errorCount;
        private FileLog log;
        private System.Timers.Timer timer;
        private int syncRun = 0;
        private Random rand;
        
        public Handler()
        {
            try
            {
                InitializeComponent();
                rand = new Random(DateTime.Now.Millisecond);
                log = new FileLog(@"c:\temp\MyService.log");
                timer = new System.Timers.Timer();
                Interlocked.Exchange(ref syncRun, 0);
                //if (!System.Diagnostics.EventLog.SourceExists("MyService"))
                //{
                //    System.Diagnostics.EventLog.CreateEventSource("MyService", "MyServiceLog");
                //}
                //eventLog.Source = "MyService";
                //eventLog.Log = "MyServiceLog";                
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }

        }

        protected override void OnStart(string[] args)
        {
            try
            {
                startTime = DateTime.Now;
                processedCount = 0;
                errorCount = 0;
                lastHeartbeat = DateTime.MinValue;
                server = Properties.Settings.Default.Server;
                database = Properties.Settings.Default.Database;
                serviceInterval = Properties.Settings.Default.ServiceInterval;
                heartbeatInterval = Properties.Settings.Default.HeartBeatInterval;
                string message = string.Format("Starting (Server: {0}; Database: {1}; Service Interval: {2} Heartbeat: {3})",
                    server, database, serviceInterval, heartbeatInterval);
                log.WriteEntry(message, EventLogEntryType.Information);
                timer.Interval = serviceInterval * 1000;
                timer.AutoReset = false;
                timer.Elapsed += new ElapsedEventHandler(OnTimer);
                Interlocked.Exchange(ref syncRun, 1);
                timer.Start();
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnPause()
        {
            try
            {
                Interlocked.Exchange(ref syncRun, 0);
                timer.Stop();
                log.WriteEntry("Paused", EventLogEntryType.Information);
                base.OnPause();
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnContinue()
        {
            try
            {
                Interlocked.Exchange(ref syncRun, 1);
                timer.Start();
                log.WriteEntry("Resumed", EventLogEntryType.Information);
                base.OnContinue();
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                Interlocked.Exchange(ref syncRun, 0);
                timer.Stop();
                string message = string.Format("Stopped (Processed: {0}; Failed: {1})", processedCount, errorCount);
                log.WriteEntry(message, EventLogEntryType.Information);
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            try
            {
                int actions,failed;
                if (syncRun == 0) return;
                DateTime now = DateTime.Now;
                HeartBeat(now);
                using (SqlConnection connection = new SqlConnection())
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = server;
                    builder.InitialCatalog = database;
                    builder.IntegratedSecurity = true;
                    connection.ConnectionString = builder.ConnectionString;
                    connection.Open();
                    int newID=-1;
                    using (SqlCommand command=new SqlCommand())
                    {
                        command.CommandText="select max(id) from testtable";
                        command.Connection=connection;
                        newID=(int)command.ExecuteScalar();
                        command.Dispose();
                    }
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        int rows=rand.Next(1,20);
                        for (int i=0;i<rows;i++)
                        {
                            command.CommandText = string.Format("insert testtable(id,number,text,lastupdate) values({0},{1},'{2}','{3}')",
                                ++newID, rand.Next(0, 1000000), "TBD", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                    actions = rand.Next(0, 10);
                    failed = rand.Next(0, actions);
                }
                string message = string.Format("Service completed (Processed: {0} Failed: {1})", actions-failed, failed);
                log.WriteEntry(message, EventLogEntryType.Information);
                processedCount += (actions - failed);
                errorCount += failed;
            }
            catch (Exception x)
            {
                log.WriteEntry(x.Message, EventLogEntryType.Error);
            }
            finally
            {
                if (syncRun > 0)
                    timer.Start();
            }
        }

        private string UpTime(DateTime now)
        {
            TimeSpan t = now.Subtract(startTime);
            return string.Format("{0} Days, {1,2:00}:{2,2:00}:{3,2:00}", t.Days, t.Hours, t.Minutes, t.Seconds);
        }

        private void HeartBeat(DateTime now)
        {
            TimeSpan heartbeatSpan = now.Subtract(lastHeartbeat);
            if (heartbeatSpan.TotalSeconds >= heartbeatInterval)
            {
                lastHeartbeat = now;
                string message = string.Format("Heartbeat (Up Time: {0})", UpTime(now));
                log.WriteEntry(message, EventLogEntryType.Information);
            }
        }
    }
}
