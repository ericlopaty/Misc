using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace CrashBurn
{
    class Processes
    {
        static void DoProcesses(string[] args)
        {
            string upt="",ppt="",tpt="";
            Console.Title="Process";
            Console.Clear();
            Process[] processes=Process.GetProcesses();
            Process p=processes[0];
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < processes.Length; i++)
                {
                    p = processes[i];
                    //Console.WriteLine(p.ProcessName,p.UserProcessorTime,p.TotalProcessorTime,p.PrivilegedProcessorTime,p.Threads,p.StartTime,p.WorkingSet,p.VirtualMemorySize,p.Responding,p.PrivateMemorySize,p.PeakWorkingSet,p.Id,p.HandleCount,p.BasePriority
                    try
                    {
                        upt = string.Format("{0,7:###0.00}", p.UserProcessorTime.TotalSeconds);
                        ppt = string.Format("{0,7:###0.00}", p.PrivilegedProcessorTime.TotalSeconds);
                        tpt = string.Format("{0,7:###0.00}", p.TotalProcessorTime.TotalSeconds);
                    }
                    catch
                    {
                        upt = "-------";
                        ppt = "-------";
                        tpt = "-------";
                    }
                    Console.WriteLine("{0,6} {1,-30} {2} {3} {4}",
                        p.Id,
                        p.ProcessName,
                        upt, ppt, tpt);
                }
                Thread.Sleep(5000);
            }
        }
    }
}
