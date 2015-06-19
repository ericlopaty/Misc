using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyManualResetEvent
{
    class MyThread
    {
        public Thread thrd;
        ManualResetEvent manualResetEvent;

        public MyThread(string name, ManualResetEvent e)
        {
            thrd = new Thread(this.run);
            thrd.Name = name;
            manualResetEvent = e;
            thrd.Start();
        }

        void run()
        {
            Console.WriteLine("Inside thread " + thrd.Name);

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(thrd.Name);
                Thread.Sleep(50);
            }

            Console.WriteLine(thrd.Name + " Done!");

            manualResetEvent.Set();
        }
    }

    class MainClass
    {
        public static void Main()
        {
            ManualResetEvent evtObj = new ManualResetEvent(false);

            MyThread myThread = new MyThread("Event Thread 1", evtObj);

            Console.WriteLine("Main thread waiting for event.");

            // Wait for signaled event.
            evtObj.WaitOne();

            Console.WriteLine("Main thread received first event.");

            evtObj.Reset();

            myThread = new MyThread("Event Thread 2", evtObj);

            // Wait for signaled event.
            evtObj.WaitOne();

            Console.WriteLine("Main thread received second event.");

        }
    }
}


  
