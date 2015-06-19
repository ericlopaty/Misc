using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBus
{
    class Logger
    {
        public enum FilterLevel
        {
            Trace = 0, Debug = 1, Info = 2, Warn = 3, Error = 4, Fatal = 5, None = 6
        }

        ListBox logDevice;
        FilterLevel logLevel;

        public Logger(ListBox logDevice, FilterLevel logLevel)
        {
            this.logDevice = logDevice;
            this.logLevel = logLevel;
        }

        public FilterLevel LogLevel
        {
            get { return logLevel; }
            set { logLevel = value; }
        }

        public void LogTrace(string source, string message)
        {
            if (logLevel >= FilterLevel.Trace)
                WriteLog(FilterLevel.Trace, source, message);
        }

        public void LogDebug(string source, string message)
        {
            if (logLevel >= FilterLevel.Debug)
                WriteLog(FilterLevel.Trace, source, message);
        }

        public void LogInfo(string source, string message)
        {
            if (logLevel >= FilterLevel.Info)
                WriteLog(FilterLevel.Trace, source, message);
        }

        public void LogWarn(string source, string message)
        {
            if (logLevel >= FilterLevel.Warn)
                WriteLog(FilterLevel.Trace, source, message);
        }

        public void LogError(string source, string message)
        {
            if (logLevel >= FilterLevel.Error)
                WriteLog(FilterLevel.Trace, source, message);
        }
        public void LogFatal(string source, string message)
        {
            if (logLevel >= FilterLevel.Fatal)
                WriteLog(FilterLevel.Trace, source, message);
        }

        public void WriteLog(FilterLevel level, string source, string message)
        {
            logDevice.Items.Add(string.Format("{0} {1} {2}", DateTime.Now.ToString("HH:mm:ss"), source, message));
            while (logDevice.Items.Count>1000)
                logDevice.Items.RemoveAt(0);
        }
    }
}
