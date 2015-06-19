using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CountUp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int s, m, h, d;
                int s2, m2, h2, d2;
                int max = 0;
                string lastLine = "";
                string line, line2;
                Console.CursorVisible = false;
                Console.Clear();
                DateTime startTime = DateTime.Parse(args[0]);
                while (true)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan elapsed = now.Subtract(startTime);
                    s = (int)elapsed.TotalSeconds;
                    m = (int)elapsed.TotalMinutes;
                    h = (int)elapsed.TotalHours;
                    d = (int)elapsed.TotalDays;
                    line = string.Format(" {0} Days | {1:#,###} Hours | {2:#,###} Minutes | {3:#,###} Seconds", d, h, m, s);
                    if (line != lastLine)
                    {
                        lastLine = line;
                        Console.SetCursorPosition(0, 1);
                        Console.Write(line.PadRight(Console.BufferWidth, ' '));
                        s2 = s;
                        d2 = s2 / 86400;
                        s2 -= (d2 * 86400);
                        h2 = s2 / 3600;
                        s2 -= (h2 * 3600);
                        m2 = s2 / 60;
                        s2 -= (m2 * 60);
                        Console.SetCursorPosition(0, 3);
                        line2 = "".PadRight(d2, 'D') + "".PadRight(h2, 'H') + "".PadRight(m2, 'M') + "".PadRight(s2, 'S');
                        max = Math.Max(line2.Length, max);
                        Console.Write(line2.PadRight(max, ' '));
                    }
                    Thread.Sleep(100);
                }
            }
            finally
            {
                Console.CursorVisible = true;
            }
        }
    }
}
