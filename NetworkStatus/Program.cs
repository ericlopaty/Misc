using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace ExampleTray
{
    static class Program
    {
        public static FormDisplay displayForm = null;
        private static NotifyIcon trayIcon;
        private static ContextMenuStrip contextMenu;
        private static Assembly assembly;
        public static bool KeepRunning = true;
        private static EventLog eventLog;
        public static int logEntries = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            assembly = Assembly.GetExecutingAssembly();

            if (!EventLog.SourceExists(Application.ProductName))
                EventLog.CreateEventSource(Application.ProductName, "Application");
            eventLog = new EventLog();
            eventLog.Source = Application.ProductName;
            eventLog.EntryWritten += new EntryWrittenEventHandler(OnEventLogEntryWritten);
            eventLog.EnableRaisingEvents = true;

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open", null, new EventHandler(OnContextOpen));
            contextMenu.Items.Add("Start", null, new EventHandler(OnContextStart));
            contextMenu.Items.Add("Pause", null, new EventHandler(OnContextPause));
            contextMenu.Items.Add("Stop", null, new EventHandler(OnContextStop));
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("Exit", null, new EventHandler(OnContextExit));

            trayIcon = new NotifyIcon();
            trayIcon.MouseDoubleClick += new MouseEventHandler(OnTrayIconDoubleClick);
            string iconFile = string.Format("{0}.icons.{1}", Application.ProductName, "gear.ico");
            Stream file = assembly.GetManifestResourceStream(iconFile);
            trayIcon.Icon = new Icon(file);
            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Text = "Sample Tray Application";
            trayIcon.Visible = true;

            eventLog.WriteEntry("Service loaded", EventLogEntryType.Information, 1, 99);
            eventLog.WriteEntry("Test Message", EventLogEntryType.SuccessAudit, 2, 99);
            eventLog.WriteEntry("Test Message", EventLogEntryType.FailureAudit, 3, 99);

            while (KeepRunning)
            {
                Application.DoEvents();
            }
            StopService();
            trayIcon.Visible = false;
            trayIcon.Dispose();
            eventLog.WriteEntry("Service Exiting", EventLogEntryType.Information, 0, 0);
            Application.Exit();
        }

        private static void OnEventLogEntryWritten(object sender, EntryWrittenEventArgs e)
        {
            if (e.Entry.Source != Application.ProductName)
                logEntries++;
        }

        private static void OnTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            if (displayForm == null)
                displayForm = new FormDisplay();
            displayForm.Show();
            displayForm.Activate();
        }

        private static void OnContextOpen(object sender, EventArgs e)
        {
            if (displayForm == null)
                displayForm = new FormDisplay();
            displayForm.Show();
            displayForm.Activate();
        }

        private static void OnContextStart(object sender, EventArgs e)
        {
            StartService();
        }

        private static void OnContextPause(object sender, EventArgs e)
        {
            PauseService();
        }

        private static void OnContextStop(object sender, EventArgs e)
        {
            StopService();
        }

        private static void OnContextExit(object sender, EventArgs e)
        {
            KeepRunning = false;
        }

        public static void StartService()
        {
            string iconFile = string.Format("{0}.icons.{1}", Application.ProductName, "servicerunning.ico");
            Stream file = assembly.GetManifestResourceStream(iconFile);
            trayIcon.Icon = new Icon(file);
            eventLog.WriteEntry("Service started", EventLogEntryType.Information, 4, 99);
        }

        public static void PauseService()
        {
            string iconFile = string.Format("{0}.icons.{1}", Application.ProductName, "servicepaused.ico");
            Stream file = assembly.GetManifestResourceStream(iconFile);
            trayIcon.Icon = new Icon(file);
            eventLog.WriteEntry("Service paused", EventLogEntryType.Warning, 5, 99);
        }

        public static void StopService()
        {
            string iconFile = string.Format("{0}.icons.{1}", Application.ProductName, "servicestopped.ico");
            Stream file = assembly.GetManifestResourceStream(iconFile);
            trayIcon.Icon = new Icon(file);
            eventLog.WriteEntry("Service stopped", EventLogEntryType.Error, 6, 99);
        }
    }
}
