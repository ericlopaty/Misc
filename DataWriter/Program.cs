using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using Log;

namespace DataWriter
{
    class Program
    {
        static Log.Level ConvertLogLevel(string level)
        {
            if (string.Compare(level, "trace", true) == 0) return Level.TRACE;
            if (string.Compare(level, "debug", true) == 0) return Level.DEBUG;
            if (string.Compare(level, "info", true) == 0) return Level.INFO;
            if (string.Compare(level, "warn", true) == 0) return Level.WARN;
            if (string.Compare(level, "error", true) == 0) return Level.ERROR;
            if (string.Compare(level, "fatal", true) == 0) return Level.FATAL;
            if (string.Compare(level, "none", true) == 0) return Level.NONE;
            return Level.NONE;
        }

        static void Main(string[] args)
        {
            // get assembly name and version
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            string rootName = assemblyName.Name;
            string version = assemblyName.Version.ToString();

            string server, database, login, password, logPath, logRoot;
            Log.Level logLevel;

            // initialize program options
            //string registryPath = string.Format("SOFTWARE\\DEV\\{0}", rootName);
            //RegistryKey root=Registry.LocalMachine.OpenSubKey(registryPath);
            //string server = (string)root.GetValue("server");            
            //string database = (string)root.GetValue("database");
            //string login = (string)root.GetValue("login");
            //string password = (string)root.GetValue("password");
            //string level = (string)root.GetValue("loglevel");
            //string logPath = (string)root.GetValue("logpath");
            //string logRoot = (string)root.GetValue("logroot");

            server = Properties.Settings.Default.DatabaseServer;
            database = Properties.Settings.Default.Database;
            login = Properties.Settings.Default.Login;
            password = Properties.Settings.Default.Password;
            logLevel = ConvertLogLevel(Properties.Settings.Default.LogFilter);
            logPath = Properties.Settings.Default.LogPath;
            logRoot = Properties.Settings.Default.LogRoot;

            Console.WriteLine(logPath);
            Console.WriteLine(logRoot);

            // set the logger
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
                }
                log.Info("Insert completed");
                cn.Close();
                log.Info("Database connection closed");
            }
            log.Info("Application terminating");
            Console.WriteLine("about to change a setting");
            Properties.Settings.Default.LogFilter = "ERROR";
            Console.WriteLine("about to save settings");
            Properties.Settings.Default.Save();
            Console.ReadLine();
        }
    }
}


/*
namespace adonet
{
    private void button1_Click(object sender, EventArgs e)
    {
      builder.AsynchronousProcessing = true;
      using (cn = new SqlConnection(builder.ConnectionString))
      {
        cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
        cn.StateChange += new StateChangeEventHandler(OnStateChange);
        cn.Open();
        //tran = cn.BeginTransaction();
        //SqlCommand cmd = cn.CreateCommand();
        //SqlCommand cmd = new SqlCommand(sql, cn);
        //cmd = cn.CreateCommand();
        //print handled by SqlInfoMessageEventHandler
        //cmd.CommandText = "PRINT 'Hello, ADO.NET'";
        //cmd.ExecuteNonQuery();
        //schema retrieval
        //tbl = cn.GetSchema("tables");
        //tbl = cn.GetSchema("tables");
        //string[] restrictions;
        //restrictions = new string[] { "Northwind", "dbo", "Customers", null };
        //tbl = cn.GetSchema("Columns", restrictions);
        //tbl = cn.GetSchema("restrictions");
        //dataGrid.DataSource=tbl;
        sql = "SELECT CustomerID, CompanyName FROM Customers";
        //cmd = new SqlCommand(strSQL, cn);
        cmd = cn.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cn;
        //int i = cmd.ExecuteNonQuery();
        //int i = (int)cmd.ExecuteScalar();
        //SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //using (SqlDataReader rdr = cmd.ExecuteReader())
        //{
        //  while (rdr.Read())
        //  {
        //    lblMessage.Text = string.Format("{0}",rdr["CompanyName"]);
        //    Application.DoEvents();
        //  }
        //}

        sql = 
          "UPDATE Products SET UnitPrice = UnitPrice * 0.85 WHERE CategoryID = 3;" +
          "UPDATE Products SET UnitPrice = UnitPrice * 1.15 WHERE CategoryID = 4;" +
          "UPDATE Products SET UnitPrice = UnitPrice * 0.75  WHERE CategoryID = 5;";
        cmd.StatementCompleted += new StatementCompletedEventHandler(OnStatementCompleted);

        
        //tran.Commit();
        //cn.ChangeDatabase("firmwide");
        MessageBox.Show(cn.Database);
        tbl = cn.GetSchema("tables");
        dataGrid.DataSource = tbl;
      }
    }

    void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
      lblMessage.Text = e.Message;
      Application.DoEvents();
    }

    void OnStateChange(object sender, StateChangeEventArgs e)
    {
      {
        lblState.Text = string.Format("StateChange from {0} to {1}", e.OriginalState, e.CurrentState);
        Application.DoEvents();
      }
    }

    static void OnStatementCompleted(object sender, StatementCompletedEventArgs e)
    {
      Console.WriteLine("Statement Affected {0} row(s)", e.RecordCount);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lbMessages.Items.Clear();
    }
  }
}
*/