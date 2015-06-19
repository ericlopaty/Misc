using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BusyBee
{
    public partial class Handler : ServiceBase
    {
        private string server="EL_LT_1\SQLEXPRESS2008";
        private string database="General";


        public Handler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
