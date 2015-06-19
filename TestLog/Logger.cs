using System;
using System.IO;
using System.Diagnostics;

namespace Toolbox
{
    public class Logger
    {
        public enum LogLevel { All = 0, Debug = 1, Info = 2, Warning = 3, Error = 4, Fatal = 5, None = 6 };

        private LogLevel logLevel;
        private string logPath;
        private string logName;
        private string logFile;
        private int rolloverSize;
        private int retentionDays;

        public Logger(string logPath, string logName, int rolloverSize, int retentionDays, LogLevel logLevel)
        {
            try
            {
                // initialize instance variables
                this.logPath = logPath;
                this.logName = logName;
                this.rolloverSize = rolloverSize;
                this.retentionDays = retentionDays;
                this.logLevel = logLevel;
                this.logFile = Path.Combine(logPath, string.Format("{0}.log", logName));

                // create log directory if necessary
                try
                {
                    if (!Directory.Exists(logPath))
                        Directory.CreateDirectory(logPath);
                }
                catch (IOException)
                {
                }

            }
            catch (Exception)
            {
            }
        }

        private void Rollover(FileInfo file)
        {
            // delete old logs

        }

        public void Log(LogLevel level, string message)
        {
            string rollTemplate = "{0}.{1}.{2}.log";
            string ymd = "yyyy-MM-dd";
            string ymdhmsf = "yyyy-MM-dd HH:mm:ss";
            string msgTemplate = "{0} {1,-7} - {2}";

            try
            {
                // lock for thread synchronization
                object t = new object();
                lock (t)
                {
                    try
                    {
                        FileInfo file = new FileInfo(logFile);
                        if ((file.Length > rolloverSize * 1024)
                            || (file.LastWriteTime.DayOfYear != DateTime.Now.DayOfYear))
                        {
                            // rollover log
                            int i = 1;
                            string rolloverName = "";
                            do
                            {
                                string lastWrite = file.LastWriteTime.ToString(ymd);
                                string testName = string.Format(rollTemplate, logName, lastWrite, i++);
                                rolloverName = Path.Combine(logPath, testName);
                            }
                            while (File.Exists(rolloverName));
                            File.Move(logFile, rolloverName);
                            // cleanup old log files
                            FileInfo[] files = new DirectoryInfo(logPath).GetFiles();
                            foreach (FileInfo f in files)
                            {
                                if (f.Name.StartsWith(logName) && f.Name.EndsWith(".log"))
                                {
                                    TimeSpan age = DateTime.Now.Subtract(f.LastWriteTime);
                                    if (Math.Floor(age.TotalDays) > retentionDays && !f.IsReadOnly)
                                        f.Delete();
                                }
                            }
                        }
                    }
                    catch (IOException)
                    {
                    }

                    // log the message
                    try
                    {
                        if (level >= this.logLevel)
                        {
                            using (StreamWriter writer = new StreamWriter(logFile, true))
                            {
                                string time = DateTime.Now.ToString(ymdhmsf);
                                writer.WriteLine(msgTemplate, time, level.ToString(), message);
                                writer.Flush();
                                writer.Close();
                            }
                        }
                    }
                    catch (IOException)
                    {
                    }
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public void Trace(string message) { Log(LogLevel.Trace, message); }
        public void Debug(string message) { Log(LogLevel.Debug, message); }
        public void Info(string message) { Log(LogLevel.Info, message); }
        public void Warn(string message) { Log(LogLevel.Warning, message); }
        public void Error(string message) { Log(LogLevel.Error, message); }
        public void Fatal(string message) { Log(LogLevel.Fatal, message); }
    }
}
