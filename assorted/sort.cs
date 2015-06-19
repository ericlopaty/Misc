using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

[assembly: AssemblyTitle("sort")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Prudential Financial")]
[assembly: AssemblyProduct("sort")]
[assembly: AssemblyCopyright("Copyright © Prudential Financial 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace sort
{
    class Program
    {
        private static int X;
        private static int Y;
        private static string alpha =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static int[] p = null;
        private static int delay = 0;

        static void Main(string[] args)
        {
            Console.Title = "Sort Demo";
            char choice;
            if (args.Length > 0)
                delay = int.Parse(args[0]);
            while ((choice = Prompt()) != '0')
            {
                Console.Clear();
                FillArray();
                Draw(0, p.Length - 1);
                switch (choice)
                {
                    case 'a':
                        Console.Title = "Bubble";
                        Bubble(0, p.Length - 1);
                        break;
                    case 'b':
                        Console.Title = "Insertion";
                        Insertion(0, p.Length - 1);
                        break;
                    case 'c':
                        Console.Title = "Butterfly";
                        Butterfly(0, p.Length - 1);
                        break;
                    case 'd':
                        Console.Title = "Butterfly";
                        ReverseButterfly(0, p.Length - 1);
                        break;
                    case 'e':
                        Console.Title = "Butterfly";
                        FastButterfly(0, p.Length - 1);
                        break;
                    case 'f':
                        Console.Title = "Quick";
                        Quick(0, p.Length - 1);
                        break;
                    case 'g':
                        Console.Title = "Merge";
                        Merge2(0, p.Length - 1);
                        break;
                }
                Console.Title = "Sort Demo";
                Console.ReadLine();
            }
        }

        private static char GetChar(char defaultValue)
        {
            try
            {
                return Console.ReadLine()[0];
            }
            catch
            {
                return defaultValue;
            }
        }

        private static char Prompt()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select sort type, leave blank to exit.");
                Console.WriteLine();
                Console.WriteLine("a: Bubble");
                Console.WriteLine("b: Insertion");
                Console.WriteLine("c: Butterfly");
                Console.WriteLine("d: Reverse Butterfly");
                Console.WriteLine("e: Fast Butterfly");
                Console.WriteLine("f: Quick Sort");
                Console.WriteLine("g: 2-way Merge Sort");
                Console.WriteLine();
                Console.Write("> ");
                return GetChar('0');
            }
        }

        private static void FillArray()
        {
            X = Console.WindowWidth;
            Y = Console.WindowHeight;
            p = new int[X * Y - 1];
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < p.Length; i++)
                p[i] = r.Next(alpha.Length);
        }

        private static void Draw(int i1, int i2)
        {
            for (int i = i1; i <= i2; i++)
            {
                Console.SetCursorPosition(i % X, i / X);
                Console.Write(alpha[p[i]]);
            }
        }

        private static void Blank(int i1, int i2)
        {
            for (int i = i1; i < i2; i++)
            {
                Console.SetCursorPosition(i % X, i / X);
                Console.Write(' ');
            }
        }

        private static bool Swap(int i, int j)
        {
            int t = p[i];
            p[i] = p[j];
            Draw(i, i);
            p[j] = t;
            Draw(j, j);
            if (delay > 0)
                Thread.Sleep(delay);
            return true;
        }

        private static void Bubble(int x1, int x2)
        {
            bool f = true;
            for (int i = x1; i < x2 && f; i++)
            {
                f = false;
                for (int j = x2; j > i; j--)
                    if (p[j] < p[j - 1])
                        f = Swap(j, j - 1);
            }
        }

        private static void Butterfly(int x1, int x2)
        {
            for (int i = x1; i < x2; i++)
                for (int j = i + 1; j <= x2; j++)
                    if (p[i] > p[j])
                        Swap(i, j);
        }

        private static void ReverseButterfly(int x1, int x2)
        {
            for (int i = x1; i < x2; i++)
                for (int j = x2; j > i; j--)
                    if (p[i] > p[j])
                        Swap(i, j);
        }

        private static void FastButterfly(int x1, int x2)
        {
            for (int i = x1; i < x2; i++)
            {
                int t = i;
                for (int j = i + 1; j <= x2; j++)
                    if (p[j] < p[t])
                        t = j;
                if (t >= i)
                    Swap(i, t);
            }
        }

        private static void Insertion(int x1, int x2)
        {
            for (int i = x1 + 1; i <= x2; i++)
            {
                int t = p[i];
                for (int j = x1; j < i; j++)
                    if (t < p[j])
                    {
                        for (int k = i - 1; k >= j; k--)
                        {
                            p[k + 1] = p[k];
                            Draw(k + 1, k + 1);
                        }
                        p[j] = t;
                        Draw(j, j);
                        break;
                    }
            }
        }

		/*
        private static void Quick(int x1, int x2)
        {
            if (x2 - x1 < 2)
                return;
            bool sorted = true;
            for (int i = x1 + 1; i <= x2 && sorted; i++)
                sorted = sorted && (p[i] >= p[i - 1]);
            if (sorted)
                return;
            List<int> lower = new List<int>();
            List<int> upper = new List<int>();
            int pivot = p[x1];
            for (int i = x1 + 1; i <= x2; i++)
            {
                if (p[i] < pivot)
                    lower.Add(p[i]);
                else
                    upper.Add(p[i]);
                Blank(i, i);
            }
            p[x1 + lower.Count] = pivot;
            Draw(x1 + lower.Count, x1 + lower.Count);
            lower.CopyTo(p, x1);
            upper.CopyTo(p, x1 + lower.Count + 1);
            Draw(x1, x2);
            if (upper.Count > lower.Count)
            {
                if (upper.Count > 1)
                    Quick(x1 + lower.Count + 1, x2);
                if (lower.Count > 1)
                    Quick(x1, x1 + lower.Count - 1);
            }
            else
            {
                if (lower.Count > 1)
                    Quick(x1, x1 + lower.Count - 1);
                if (upper.Count > 1)
                    Quick(x1 + lower.Count + 1, x2);
            }
        }
		*/

        private static void Quick(int x1, int x2)
        {
            int i = x1, j = x2;
            int pivot = (x1 + x2) / 2;
            while (i <= j)
            {
                while (p[i] < p[pivot])
                    i++;
                while (p[j] > p[pivot])
                    j--;
                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (x1 < j)
                Quick(x1, j);
            if (i < x2)
                Quick(i, x2);
        }

        private static void Merge2(int x1, int x2)
        {
            int runSize = x2 - x1 + 1;
            int runCount = 1;
            int t1, t2;
            List<Pairs> runs = new List<Pairs>();
            List<Pairs> runs2 = new List<Pairs>();

            while (runSize > 50)
            {
                runSize /= 2;
                runCount *= 2;
            }

            t1 = 0;
            for (int i = 0; i < runCount; i++)
            {
                t2 = t1 + runSize;
                if (t2 >= x2) t2 = x2;
                runs.Add(new Pairs(t1, t2));
                FastButterfly(t1, t2);
                t1 = t2 + 1;
            }

            while (runs.Count > 1)
            {
                Pairs run1 = runs[0];
                Pairs run2 = runs[1];
                int count1 = run1.High - run1.Low + 1;
                int count2 = run2.High - run2.Low + 1;
                int[] target = new int[count1 + count2];
                int t = 0;
                t1 = run1.Low;
                t2 = run2.Low;
                while (t1 <= run1.High || t2 <= run2.High)
                {
                    if (t1 > run1.High)
                    {
                        Blank(t2, t2);
                        target[t++] = p[t2++];
                    }
                    else if (t2 > run2.High)
                    {
                        Blank(t1, t1);
                        target[t++] = p[t1++];
                    }
                    else if (p[t1] < p[t2])
                    {
                        Blank(t1, t1);
                        target[t++] = p[t1++];
                    }
                    else
                    {
                        Blank(t2, t2);
                        target[t++] = p[t2++];
                    }
                }
                for (int i = 0, j = run1.Low; i < target.Length; i++, j++)
                    p[j] = target[i];
                Draw(run1.Low, run2.High);
                runs2.Add(new Pairs(run1.Low, run2.High));
                runs.RemoveRange(0, 2);
                if (runs.Count == 0)
                {
                    runs.AddRange(runs2);
                    runs2.RemoveRange(0, runs2.Count);
                }
            }
        }
    }

    class Pairs
    {
        public int Low, High;

        public Pairs(int low, int high)
        {
            Low = low;
            High = high;
        }
    }
}
