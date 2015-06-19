using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExampleConsole
{
    [Chapter(12)]
    class Events
    {
        public static void Dispatch()
        {
            Clock clock = new Clock();
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(clock);
            LogTime lt = new LogTime();
            lt.Subscribe(clock);

            clock.OnSecondChange += new Clock.SecondChangeHandler(AnotherHandler);

            clock.Run();
        }

        public static void AnotherHandler(object clock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Handled: {0,2:00}:{1,2:00}:{2,2:00}", ti.hour, ti.minute, ti.second);
        }

    }

    [Chapter(12)]
    public class TimeInfoEventArgs : EventArgs
    {
        public readonly int hour, minute, second;

        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }

    // a class that publishes and fires events
    [Chapter(12)]
    public class Clock
    {
        private int hour, minute, second;

        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);

        public event SecondChangeHandler OnSecondChange;

        public void Run()
        {
            for (; ; )
            {
                Thread.Sleep(10);
                DateTime dt = DateTime.Now;
                if (dt.Second != second)
                {
                    TimeInfoEventArgs timeInfo = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    if (OnSecondChange != null)
                    {
                        OnSecondChange(this, timeInfo);
                    }
                }
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }

    // a class that will subscribe to and handle an event
    [Chapter(12)]
    public class DisplayClock
    {
        public void Subscribe(Clock clock)
        {
            clock.OnSecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }

        public void TimeHasChanged(object clock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current Time: {0,2:00}:{1,2:00}:{2,2:00}", ti.hour, ti.minute, ti.second);
        }
    }

    // a class that will subscribe to and handle an event
    [Chapter(12)]
    public class LogTime
    {
        public void Subscribe(Clock clock)
        {
            clock.OnSecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }

        public void WriteLogEntry(object clock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Logging: {0,2:00}:{1,2:00}:{2,2:00}", ti.hour, ti.minute, ti.second);
        }
    }
}
