using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(7)]
    public struct LocationClass
    {
        private int x, y;

        public LocationClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0}/{1}]", x, y);
        }
    }

    [Chapter(7)]
    public struct LocationStruct
    {
        private int x, y;

        public LocationStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0}/{1}]", x, y);
        }
    }

    [Chapter(7)]
    class Structs
    {
        public static void Dispatch()
        {
            StructTester();
        }

        private static void StructFunc1(LocationStruct ls)
        {
            ls.X = 5;
            Console.WriteLine("pass by value: {0}", ls);
        }

        private static void StructFunc2(ref LocationStruct ls)
        {
            ls.X = 5;
            Console.WriteLine("pass by reference: {0}", ls);
        }

        private static void ClassFunc1(LocationClass lc)
        {
            lc.X = 5;
            Console.WriteLine("pass class: {0}", lc);
        }

        private static void StructTester()
        {
            LocationClass lc = new LocationClass(1, 2);
            LocationStruct ls = new LocationStruct(3, 4);
            Console.WriteLine("class, before: {0}", lc);
            ClassFunc1(lc);
            Console.WriteLine("class, after: {0}", lc);

            Console.WriteLine("stuct, before: {0}", ls);
            StructFunc1(ls);
            Console.WriteLine("struct, after: {0}", ls);

            StructFunc2(ref ls);
            Console.WriteLine("struct after: {0}", ls);
        }

    }
}
