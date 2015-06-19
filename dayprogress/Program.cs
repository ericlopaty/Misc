using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dayprogress
{
    class Program
    {
        private static System.Timers.Timer t;
        private static DateTime target;
        private static string caption = "";

        static void Main(string[] args)
        {
            Console.Clear();
            DateTime now=DateTime.Now;
            target = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);
            using (t = new System.Timers.Timer())
            {
                t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
                t.Interval = 1000;
                t.AutoReset = true;
                t.Enabled = true;
                Console.ReadLine();
                t.Enabled = false;
                t.Close();
            }
        }
        static void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            TimeSpan span = target.Subtract(DateTime.Now);
            int m = (int)span.TotalMinutes;
            if (m < 0) m = 0;
            string newCaption = string.Format("{0}","".PadRight(m, '#'));
            if (string.Compare(caption, newCaption) != 0)
            {
                Console.Title = m.ToString();
                Console.Clear();
                Console.WriteLine(newCaption);
                caption = newCaption;
            }
        }
    }
}
