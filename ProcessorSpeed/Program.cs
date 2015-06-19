using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading;

namespace ProcessorSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var query = new SelectQuery("Win32_Processor");
                var searcher = new ManagementObjectSearcher(query);
                while (true)
                {
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        UInt32 currentSpeed = (UInt32)mo["CurrentClockSpeed"];
                        UInt32 maxSpeed = (UInt32)mo["MaxClockSpeed"];
                        double pctMax = (double)currentSpeed / (double)maxSpeed * 100;
                        Console.WriteLine("{0} / {1} = {2:##0.#}%", currentSpeed, maxSpeed, pctMax);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error collecting machine information: {0}", ex.Message);
            }
        }
    }
}
