using System;
using System.Diagnostics;
using System.IO;

namespace MyService
{
    class FileLog
    {
        string logFile;

        public FileLog(string logFile)
        {
            this.logFile = logFile;
        }

        public void WriteEntry(string message, EventLogEntryType entryType)
        {
            try
            {
                File.AppendAllText(logFile, string.Format("[{0}] {1}: {2}\n",
                    string.Format("{0:MM/dd/yy hh:mm:ss tt}", DateTime.Now), entryType, message));
            }
            catch
            {
            }
        }
    }
}
