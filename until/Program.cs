using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace until
{
    class Program
    {
        static List<Event> events = new List<Event>();
        static ArrayList display = new ArrayList();

        static void Main(string[] args)
        {
            Console.Title = "Until";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("software\\eric\\until");
            string[] list = key.GetValueNames();
            foreach (string item in list)
                events.Add(new Event(item, DateTime.Parse((string)key.GetValue(item))));
            while (events.Count>0)
            {
                display = new ArrayList();
                int t = 0;
                while (t < events.Count)
                {
                    if (events[t].Days < -1.0)
                    {
                        key.DeleteValue(events[t].Title);
                        events.RemoveAt(t);
                    }
                    else
                    {
                        display.Add(events[t].ToString());
                        t++;
                    }
                }
                display.Sort();
                Console.Clear();
                Console.WriteLine();
                for (int i = 0; i < display.Count; i++)
                {
                    int days = int.Parse(display[i].ToString().Substring(0, 4));
                    if (days <= 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (days < 7)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(display[i]);
                }
                Console.WriteLine();
                int day = DateTime.Now.Day;
                while (DateTime.Now.Day == day)
                    Thread.Sleep(1000);
            }
        }
    }

    class Event
    {
        private string title;
        private DateTime due;

        public Event(string title, DateTime due)
        {
            this.title = title;
            this.due = due;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime Due
        {
            get { return due; }
            set { due = value; }
        }

        public int Days
        {
            get
            {
                double d = due.Subtract(DateTime.Now).TotalDays;
                if (d > 0)
                    return (int)Math.Ceiling(d);
                else if (d <= 0 && d > -1.0)
                    return 0;
                else
                    return (int)Math.Floor(d);
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0,4:0}: {1}", Days, title);
        }
    }
}
