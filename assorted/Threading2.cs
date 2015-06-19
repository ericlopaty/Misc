using System;
using System.Threading;

/*
Wrapper class 'ThreadWrapper' encapsulates the logic to start the thread with 
parameters passed into its constructor.
*/

namespace Threading2
{
  class Program
  {
    static void Main(string[] args)
    {
      ThreadWrapper tw = new ThreadWrapper("abcdefghijklmnopqrstuvwxyz", 250);
      Thread t;
      t = tw.Start();
      t.Join();
      Console.WriteLine("worker done");
    }
  }

  class ThreadWrapper
  {
    protected string letters;
    protected int interval;
    Thread thread;

    public ThreadWrapper(string letters,int interval)
    {
      this.letters = letters;
      this.interval = interval;
    }

    void ThreadProc()
    {
      try
      {
        Console.WriteLine("worker... start");
        DumpLetters("worker", "abcdefghijklmnopqrstuvwxyz", 250);
        Console.WriteLine("worker... complete");
      }
      catch (System.Threading.ThreadInterruptedException)
      {
        Console.WriteLine("worker... interrupted");
      }
      finally
      {
        Console.WriteLine("worker... exiting");
      }
    }

    public Thread Start()
    {
      thread = new Thread(new ThreadStart(ThreadProc));
      thread.Start();
      return thread;
    }

    private void DumpLetters(string prefix, string letters, int interval)
    {
      for (int i = 0; i < letters.Length; i++)
      {
        Console.WriteLine("{0}... {1}", prefix, letters[i]);
        Thread.Sleep(interval);
      }
    }
  }
}
