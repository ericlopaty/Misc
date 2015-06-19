using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(3)]
    public static class Miscellaneous
    {
        [Chapter(Number = 3)]
        enum Temps
        {
            Freeze = 32,
            Room = 68,
            Boil = 212,
        }

        enum Colors
        {
            Red, Green, Blue
        }

        [Chapter(3)]
        public static void Dispatch()
        {
            Types();
            SwitchStatements();
            IfStatement();
            GotoStatement();
            WhileLoop();
            DoLoop();
            ForLoop();
            ContinueStatement();
            BreakStatement();
            ModulusOperator();
            ShortCut();
            TernaryOperator();
            NameSpaceExample();
            DebugExample();
        }

        [Chapter(3)]
        public static void Types()
        {
            sbyte sb;   // -128 to 127
            short sh;   // -32,768 to 32,767
            int i;      // -2,147,483,648 to 2,147,483,647
            long l;     // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

            l = 123;
            i = (int)l;
            sh = (short)i;
            sb = (sbyte)sh;

            Console.WriteLine("{0} {1} {2} {3}", l, i, sh, sb);

            byte b;     // 0 to 255
            ushort us;  // 0 to 65535
            uint ui;    // 0 to 4,294,967,295
            ulong ul;   // 0 to 18,446,744,073,709,551,615

            ul = 123;
            ui = (uint)ul;
            us = (ushort)ui;
            b = (byte)us;

            Console.WriteLine("{0} {1} {2} {3}", ul, ui, us, b);

            char c;
            c = 'a';
            Console.WriteLine(c);

            bool bl;
            bl = (c == 'a');
            Console.WriteLine("{0}", bl);

            float f;    // single precision float
            double d;   // double precision float
            decimal dl; // 28 digit decimal

            dl = 123.456M;
            d = (double)dl;
            f = (float)d;

            Console.WriteLine("{0} {1} {2}", dl, d, f);

            const int freeze = 32;
            Console.WriteLine("water freezes at {0}", freeze);
            i = (int)Temps.Boil;
            Console.WriteLine("water boils at {0}", i);

            Console.WriteLine("{0}", Colors.Red);
            Console.WriteLine("{0}", (int)Colors.Red);
        }

        [Chapter(Number = 3)]
        public static void SwitchStatements()
        {
            Colors c = Colors.Green;
            switch (c)
            {
                case Colors.Red:
                    Console.WriteLine("red");
                    break;
                case Colors.Green:
                    Console.WriteLine("green");
                    break;
                case Colors.Blue:
                    Console.WriteLine("blue");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }

            string c2 = "blue";
            switch (c2)
            {
                case "red":
                    Console.WriteLine("red");
                    break;
                case "green":
                    Console.WriteLine("green");
                    break;
                case "blue":
                    Console.WriteLine("blue");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }

        }

        [Chapter(Number = 3)]
        public static void IfStatement()
        {
            int i = 6;
            if (i < 10)
            {
                Console.WriteLine("less than 10");
                if (i > 5)
                {
                    Console.WriteLine("but greater than 5");
                }
            }
            else
            {
                Console.WriteLine("greater or equal 10");
            }
        }

        [Chapter(Number = 3)]
        public static void GotoStatement()
        {
            int i = 0;
        loop:
            Console.WriteLine(i);
            i++;
            if (i < 10)
                goto loop;
        }

        [Chapter(Number = 3)]
        public static void WhileLoop()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }

        [Chapter(Number = 3)]
        public static void DoLoop()
        {
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);
        }

        [Chapter(Number = 3)]
        public static void ForLoop()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);
        }

        [Chapter(Number = 3)]
        public static void ContinueStatement()
        {
            for (int i = 0; i < 20; i++)
            {
                if (i >= 5 && i <= 15)
                    continue;
                Console.WriteLine(i);
            }
        }

        [Chapter(Number = 3)]
        public static void BreakStatement()
        {
            string signal = "0";
            while (signal != "X")
            {
                Console.Write("Signal: ");
                signal = Console.ReadLine();
                if (signal == "A")
                {
                    Console.WriteLine("abort");
                    break;
                }
                if (signal == "0")
                {
                    Console.WriteLine("pass");
                    continue;
                }
                Console.WriteLine("do work");
            }
        }

        [Chapter(Number = 3)]
        public static void ModulusOperator()
        {
            for (int i = 0; i <= 20; i++)
                Console.WriteLine("{0} % {1} = {2} AND {3} / {4} = {5}", i, 7, i % 7, i, 7, i / 7);
        }

        [Chapter(Number = 3)]
        public static void ShortCut()
        {
            int i = 5;
            int j = 12;

            Console.WriteLine("{0} {1}", i, j);
            if (i++ > 5 && j++ > 10)
                Console.WriteLine("if executed");
            Console.WriteLine("{0} {1}", i, j);
        }

        [Chapter(Number = 3)]
        public static void TernaryOperator()
        {
            int i = 10;
            Console.WriteLine((i <= 10) ? "up to 10" : "above 10");
        }

        [Chapter(Number = 3)]
        public static void NameSpaceExample()
        {
            ExamplesNew.Tester1 t = new ExamplesNew.Tester1();
            t.Doit();
        }

        [Chapter(Number = 3)]
        public static void DebugExample()
        {
#if DEBUG
            Console.WriteLine("debug code");
#endif
            Console.WriteLine("normal code");
        }

        [Chapter(Number = 3)]
        public static void Boxing()
        {
            int i = 123;
            object o = i;
            int j = (int)o;
            Console.Write("j={0}", j);
        }
    }
}
