using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace customexception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                c1();
            }
            catch (FubarException fe)
            {
                Console.WriteLine(fe.MoreInfo);
            }
        }

        static void c1()
        {
            try
            {
                c2();
            }
            catch (System.Exception x)
            {
                if (x.GetType().ToString() == "customexception.FubarException")
                    throw x;
                Console.WriteLine("no good");
            }
        }

        static void c2()
        {
            c3();
        }

        static void c3()
        {
            Fubar.Method(5);
        }
    }
}
