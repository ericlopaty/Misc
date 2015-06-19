using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Weight
{
    static class Program
    {
        public static DateTime StartTime;
        public static double StartWeight;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                StartTime = DateTime.Parse(args[0]);
                StartWeight = double.Parse(args[1]);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            catch (Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message));
            }
        }
    }
}
