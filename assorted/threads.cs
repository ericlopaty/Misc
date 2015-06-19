using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args.Length == 0)
				return;
			int max = int.Parse(args[0]);
            Thread[] threads = new Thread[max];
            Random r = new Random(DateTime.Now.Millisecond);
            Console.SetWindowSize(80, max * 5 / 80 + 1);
            List<int> indexPool = new List<int>();
            for (int i = 0; i < max; i++)
                indexPool.Add(i);
            Console.Clear();
            for (int i = 0; i < max; i++)
            {
                int s = r.Next(indexPool.Count);
                int t = indexPool[s];
                indexPool.RemoveAt(s);
                threads[i] = new Thread(new Worker(t).LogLoop);
                threads[i].Start();
                Console.Title = string.Format("{0}", i);
            }
            Console.ReadLine();
        }
    }

    class Worker
    {
        private static object syncRoot = new object();
        private static volatile int sum;
        private static volatile int threads;
        private static Random r = null;
        private int t;
        private int c;
        
        static Worker()
        {
			r = new Random(DateTime.Now.Millisecond);
			sum = 0;
			threads = 0;
		}
        
        public Worker(int t)
        {
			this.c = 2000;
			threads++;
            this.t = t;
            lock (syncRoot)
            {
				sum += c;			            
	            Console.Title = string.Format("{0} {1} ", threads, sum);
			}
        }

        public void LogLoop()
        {
            while (c >= -1 )
            {
                lock (syncRoot)
                {
                    Console.SetCursorPosition((t * 4) % 80, (t * 4) / 80);
                    if (c < 0)
	                    Console.Write("----");
	                else
	                    Console.Write("{0,4}", c);
	            	Console.Title = string.Format("{0} {1}", threads, sum);
	                if (c > 0) sum--;
	                c--;
                }         
            }
            lock (syncRoot)
            {
            	threads--;
            	Console.Title = string.Format("{0} {1}", threads, sum);
			}
        }
    }
}
