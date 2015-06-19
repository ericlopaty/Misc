using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CommonLib
{
    public enum LogLevel
    {
        All = 0, Debug = 1, Info = 2, Warn = 3, Error = 4, Fatal = 5, None = 6
    }

    public class Logger
    {

        private string logPath;
        private string logName;
        private int maxSize;
        private LogLevel level;
        private string logFileName = "";
        private string backupFileName = "";
        private static object sync = null;
        private static List<string> logBuffer = new List<string>();

        static Logger()
        {
            sync = new object();
        }

        public Logger(string logName, LogLevel threshold, int maxSize,int rolloverCount)
        {
            try
            {
                this.logPath = logPath;
                this.logName = logName;
                this.maxSize = maxSize;
                if (logPath.Length > 0 && logName.Length > 0)
                {
                    if (!Directory.Exists(logPath))
                        Directory.CreateDirectory(logPath);
                    logFileName = Path.Combine(logPath, string.Format("{0}.log", logName));
                    backupFileName = Path.Combine(logPath, string.Format("{0}.log.bak", logName));
                    this.level = level;
                }
                else
                {
                    this.level = LogLevel.None;
                }
            }
            catch (IOException x)
            {
                throw new Exception(string.Format("IO ERROR: Unable to initialize logger ({0})", x.Message));
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("ERROR: Unable to initialize logger ({0})", x.Message));
            }
        }

        public LogLevel Level
        {
            get { return this.level; }
            set { level = value; }
        }

        public int MaxSize
        {
            get { return this.maxSize; }
            set { this.maxSize = value; }
        }

        public void LogTrace(string message) { LogMessage(message, LogLevel.Trace); }
        public void LogDebug(string message) { LogMessage(message, LogLevel.Debug); }
        public void LogInfo(string message) { LogMessage(message, LogLevel.Info); }
        public void LogWarn(string message) { LogMessage(message, LogLevel.Warn); }
        public void LogError(string message) { LogMessage(message, LogLevel.Error); }
        public void LogFatal(string message) { LogMessage(message, LogLevel.Fatal); }

        public void LogMessage(string message, LogLevel level)
        {
            try
            {
                if (level >= this.level)
                {
                    lock (sync)
                    {
                        if (File.Exists(logFileName))
                        {
                            FileInfo fi = new FileInfo(logFileName);
                            if (fi.Length > (maxSize * 1048576))
                            {
                                if (File.Exists(backupFileName))
                                    File.Delete(backupFileName);
                                File.Move(logFileName, backupFileName);
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(logFileName, true))
                        {
                            writer.WriteLine("{0,19} {1,-5}: {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), level.ToString(), message);
                            writer.Flush();
                            writer.Close();
                        }
                        //if (type ==AppLogEntry.Error || type==AppLogEntry.Fatal)
                        //    using (EventLog eventLog = new EventLog())
                        //    {
                        //        EventLogEntryType entryType = (type == ogLevel.WARN) ? EventLogEntryType.Warning : EventLogEntryType.Error;
                        //        eventLog.Source = logName;
                        //        eventLog.WriteEntry(message, entryType, eventID, category);
                        //        eventLog.Close();
                        //    }
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error ({0}) occurred during logging.", x.Message));
            }
        }

        public static void LogMessage(string message, LogLevel level, string logPath, string logName)
        {
            try
            {
                lock (sync)
                {
                    string fileName = Path.Combine(logPath, logName + ".log");
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine("{0,19} {1,-5}: {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), level.ToString(), message);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error ({0}) occurred during logging.", x.Message));
            }
        }
    }
}
