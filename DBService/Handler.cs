using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DBService
{
    public partial class Handler : ServiceBase
    {
        private DateTime lastServiced;
        private string server;
        private string database;

        public Handler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            lastServiced = new DateTime(1900, 1, 1);
            server = Properties.Settings.Default.SERVER;
            database = Properties.Settings.Default.DATABASE;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(lastServiced);
            if (span.TotalHours < 1)
                return;
            using (SqlConnection connection=new SqlConnection())
            {
                SqlConnectionStringBuilder builder=new SqlConnectionStringBuilder();
                builder.DataSource=server;
                builder.InitialCatalog=database;
                builder.IntegratedSecurity=true;
                connection.ConnectionString=builder.ConnectionString;
                connection.Open();
                using (SqlCommand command=new SqlCommand())
                {
                }
                connection.Close();
            }
            lastServiced = DateTime.Now;
        }
    }
}
