using System;
using System.Threading;

/*
Create two threads manually.  Main is blocked until both 
threads complete.
*/

namespace Threading1
{
  class Program
  {
    static void Main(string[] args)
    {
      Thread t1 = new Thread(new ThreadStart(MyIdleThread1));
      Thread t2 = new Thread(new ThreadStart(MyIdleThread2));
      t1.Priority = ThreadPriority.Lowest;
      t2.Priority = ThreadPriority.Lowest;
      t1.Start();
      t2.Start();

      t1.Join();
      t2.Join();

      Console.WriteLine("all threads complete");
    }

    static void MyIdleThread1()
    {
      try
      {
        Console.WriteLine("one... starting");
        DumpLetters("one", "abcdefghijklmnopqrstuvwxyz", 200);
        Console.WriteLine("one... complete");
      }
      catch (System.Threading.ThreadInterruptedException)
      {
        Console.WriteLine("one... interrupted");
      }
      finally
      {
        Console.WriteLine("one... exiting");
      }
    }

    static void MyIdleThread2()
    {
      string gap = "                    ";
      try
      {
        Console.WriteLine("{0}two... starting", gap);
        DumpLetters(gap + "two", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 500);
        Console.WriteLine("{0}two... complete", gap);
      }
      catch (System.Threading.ThreadInterruptedException)
      {
        Console.WriteLine("{0}two... interrupted", gap);
      }
      finally
      {
        Console.WriteLine("{0}two... exiting", gap);
      }
    }

    static void DumpLetters(string prefix, string letters, int interval)
    {
      for (int i = 0; i < letters.Length; i++)
      {
        Console.WriteLine("{0}... {1}", prefix, letters[i]);
        Thread.Sleep(interval);
      }
    }
  }
}
