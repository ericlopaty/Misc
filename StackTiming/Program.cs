using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace StackTiming
{
    class Program
    {
        static int testStart1, testEnd1, elapsed1;
        static int testStart2, testEnd2, elapsed2;
        static List<string> items1, items2;
        static string item1,item2;
        static int c1 = 0, c2 = 0;
        static readonly int ITERATIONS = 10000;

        static void Main(string[] args)
        {
            Test1();
            Test2();
            Console.WriteLine();
            Console.WriteLine("Test1: {0}", (double)elapsed1 / (double)c1);
            Console.WriteLine("Test2: {0}", (double)elapsed2 / (double)c2);
            Console.ReadLine();
        }

        private static void Test1()
        {
            testStart1 = Environment.TickCount;
            items1 = new List<string>();
            Test1Level2();
            testEnd1 = Environment.TickCount;
            elapsed1 = testEnd1 - testStart1;
        }

        private static void Test1Level2()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                item1 = "";
                Test1Level3();
                items1.Add(item1);
                Console.Write("{0} ", i);
            }
        }

        private static void Test1Level3()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                c1++;
                Test1Level4();
            }
        }

        private static void Test1Level4()
        {
            item1 += (new StackTrace().GetFrame(1).GetMethod().Name[0]);
        }

        private static void Test2()
        {
            testStart2 = Environment.TickCount;
            items2 = new List<string>();
            Test2Level2();
            testEnd2 = Environment.TickCount;
            elapsed2 = testEnd2 - testStart2;
        }

        private static void Test2Level2()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                item2 = "";
                Test2Level3();
                items2.Add(item2);
                Console.Write("{0} ", i);
            }
        }

        private static void Test2Level3()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                c2++;
                Test2Level4();
            }
        }

        private static void Test2Level4()
        {
            item2 += DateTime.Now.ToString()[0];
        }
    }
}
