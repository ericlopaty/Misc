using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace pexp
{
    class Item
    {
        public string ProcessName;
        public int PID;
        public string UserTime;
        public string PrivTime;
        public string TotalTime;
        public bool Responding;
        public long Memory;
        public int Threads;
        public int Handles;

        public Item(Process p)
        {
            ProcessName = p.ProcessName;
            PID = p.Id;
            double s = p.UserProcessorTime.TotalSeconds;
            int h = (int)s / 3600;
            s -= (h * 3600);
            int m = (int)s / 60;
            s -= (m * 60);
            UserTime = string.Format("{0:N0}:{1,2:00}:{2,5:00.00}", h, m, s);
            s = p.PrivilegedProcessorTime.TotalSeconds;
            h = (int)s / 3600;
            s -= (h * 3600);
            m = (int)s / 60;
            s -= (m * 60);
            PrivTime = string.Format("{0:0}:{1,2:00}:{2,5:00.00}", h, m, s);
            s = p.TotalProcessorTime.TotalSeconds;
            h = (int)s / 3600;
            s -= (h * 3600);
            m = (int)s / 60;
            s -= (m * 60);
            TotalTime = string.Format("{0:0}:{1,2:00}:{2,5:00.00}", h, m, s);
            Responding = p.Responding;
            Memory = p.PrivateMemorySize64;
            Threads = p.Threads.Count;
            Handles = p.HandleCount;
        }
    }
}

