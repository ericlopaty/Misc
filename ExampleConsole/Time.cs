using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(Number=4)]
    public static class TimeTester
    {
        public static void Dispatch()
        {
            StarterClasses();
            CopyConstructor();
            DisposeCalls();
            ParmPassing();
        }

        public static void StarterClasses()
        {
            Time t = new Time(DateTime.Now);
            Console.WriteLine("{0}", Time.InstanceCount());
            t.DisplayCurrentTime();
            t = new Time(2009, 2, 2);
            Console.WriteLine("{0}", Time.InstanceCount());
            t.DisplayCurrentTime();
            t.SetCurrentTime(2008, 1, 1, 12, 0, 0);
            t.DisplayCurrentTime();
        }

        public static void CopyConstructor()
        {
            Time t = new Time(DateTime.Now);
            Console.WriteLine("{0}", Time.InstanceCount());
            t.DisplayCurrentTime();
            Time u = new Time(t);
            Console.WriteLine("{0}", Time.InstanceCount());
            u.DisplayCurrentTime();
        }

        public static void DisposeCalls()
        {
            using (Time t = new Time(DateTime.Now))
            {
                Console.WriteLine(Time.InstanceCount());
                t.DisplayCurrentTime();
            }
            Console.WriteLine(Time.InstanceCount());
        }

        public static void ParmPassing()
        {
            Time t = new Time(DateTime.Now);
            int h, m, s;
            t.GetTimeOut(out h, out m, out s);
            Console.WriteLine("{0,2:00}:{1,2:00}:{2,2:00}", h, m, s);
            h = 0;
            m = 0;
            s = 0;
            t.GetTimeRef(ref h, ref m, ref s);
            Console.WriteLine("{0,2:00}:{1,2:00}:{2,2:00}", h, m, s);
        }
    }

    class Time:IDisposable
    {
        private int year;
        private int month;
        private int day;
        private int hour = 0;
        private int minute = 0;
        private int second = 0;
        private bool isDisposed = false;

        public readonly int ThisYear = 2009;

        private static int instanceCount;

        static Time()
        {
            instanceCount = 0;
        }
        
        public Time(System.DateTime dt)
        {
            this.year = dt.Year;
            this.month = dt.Month;
            this.day = dt.Day;
            this.hour = dt.Hour;
            this.minute = dt.Minute;
            this.second = dt.Second;
            instanceCount++;
        }

        public Time(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            instanceCount++;
        }

        public Time(Time t)
        {
            this.year = t.year;
            this.month = t.month;
            this.day = t.day;
            this.hour = t.hour;
            this.minute = t.minute;
            this.second = t.second;
            instanceCount++;
        }

        public void DisplayCurrentTime()
        {
            Console.WriteLine("{0,2:00}/{1,2:00}/{2,4:0000} {3,2:00}:{4,2:00}:{5,2:00}",
                this.month, this.day, this.year, this.hour, this.minute, this.second);
        }

        public void SetCurrentTime(int year, int month, int day, int hour, int minute, int second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public static int InstanceCount()
        {
            return instanceCount;
        }

        public void GetTimeRef(ref int hour, ref int minute, ref int second)
        {
            hour = this.hour;
            minute = this.minute;
            second = this.second;
        }

        public void GetTimeOut(out int hour, out int minute, out int second)
        {
            hour = this.hour;
            minute = this.minute;
            second = this.second;
        }

        public int Hour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return this.minute;
            }
            set
            {
                this.minute = value;
            }
        }

        ~Time()
        {
            Dispose(false);
            Console.WriteLine("In destructor");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    Console.WriteLine("not in destructor, ok to reference objects");
                }
                Console.WriteLine("disposing...");
                instanceCount--;
            }
            this.isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
