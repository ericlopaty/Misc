using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Messenger
{
    static class Program
    {
        public static string LeftSide, RightSide;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                LeftSide = args[0];
                RightSide = args[1];
            }
            else
            {
                MessageBox.Show("Need two arguments.", "Invalid Startup Options", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formHost());
        }
    }
}
