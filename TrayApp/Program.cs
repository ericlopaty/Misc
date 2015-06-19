using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace TrayApp
{
    static class Program
    {
        public static bool HideWhenMinimized;
        public static System.Reflection.Assembly Assembly;
        //public static int Height, Width, Left, Top, WindowState;
        public static FormStatus statusForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GetSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTrayApp());
        }

        public static void GetSettings()
        {
            string keyPath = string.Format(
                "SOFTWARE\\{0}\\{1}", Application.CompanyName, Application.ProductName);
            RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);
            HideWhenMinimized = (bool)((int)key.GetValue("HideWhenMinimized", 0) == 1);
            key.Close();
            Assembly = System.Reflection.Assembly.GetExecutingAssembly();
        }

        public static void SaveSettings()
        {
            string keyPath = string.Format(
                "SOFTWARE\\{0}\\{1}", Application.CompanyName, Application.ProductName);
            RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);
            key.SetValue("HideWhenMinimized", (HideWhenMinimized) ? 1 : 0, RegistryValueKind.DWord);
            key.Flush();
            key.Close();
        }
    }
}
