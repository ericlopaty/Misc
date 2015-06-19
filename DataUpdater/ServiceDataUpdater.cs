using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using Log;
using System.Threading;


namespace DataUpdater
{
    public partial class ServiceDataUpdater : ServiceBase
    {
        public ServiceDataUpdater()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        private void ProcessData()
        {
            // get assembly name and version
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            string rootName = assemblyName.Name;
            string version = assemblyName.Version.ToString();

            // initialize program options
            string registryPath = string.Format("SOFTWARE\\DEV\\{0}", rootName);
            RegistryKey root=Registry.LocalMachine.OpenSubKey(registryPath);
            string server = (string)root.GetValue("server");
            string database = (string)root.GetValue("database");
            string login = (string)root.GetValue("login");
            string password = (string)root.GetValue("password");
            string level = (string)root.GetValue("loglevel");
            string logPath = (string)root.GetValue("logpath");
            string logRoot = (string)root.GetValue("logroot");

            // set the logger
            Log.Level logLevel = Level.NONE;
            if (string.Compare(level, "trace", true) == 0) logLevel = Level.TRACE;
            if (string.Compare(level, "debug", true) == 0) logLevel = Level.DEBUG;
            if (string.Compare(level, "info", true) == 0) logLevel = Level.INFO;
            if (string.Compare(level, "warn", true) == 0) logLevel = Level.WARN;
            if (string.Compare(level, "error", true) == 0) logLevel = Level.ERROR;
            if (string.Compare(level, "fatal", true) == 0) logLevel = Level.FATAL;
            if (string.Compare(level, "none", true) == 0) logLevel = Level.NONE;
            Logger log = new Logger(logPath, logRoot, logLevel);

            log.Info(string.Format("Starting {0} v{1}",rootName,version));

            // build sql connection info
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.IntegratedSecurity = false;
            builder.MinPoolSize = 0;
            builder.MaxPoolSize = 10;
            builder.Pooling = true;
            builder.UserID = login;
            builder.Password = password;
            log.Info("Server: " + server);
            log.Info("Database: " + database);
            log.Info("Database Login: " + login);
            log.Info("Logging Level: " + logLevel.ToString());
            log.Info(string.Format("SQL Connection String {0}", builder.ConnectionString));
            
            // write 100 new rows to the numbers table
            using (SqlConnection cn = new SqlConnection(builder.ConnectionString))
            {
                cn.Open();
                log.Info("Database connection opened");
                Random r = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < 100; i++)
                {
                    int j=r.Next(1000);
                    string sql = string.Format("INSERT numbers(number) VALUES({0})", j);
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt != 1)
                        log.Error(string.Format("Insert Failed: {0}", j));
                    else
                        log.Info(string.Format("Insert {0}", j));
                }
                cn.Close();
                log.Info("Database connection closed");
            }
            log.Info("Application terminating");
        }

        private void serviceInterval_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(
        }
    }
}
