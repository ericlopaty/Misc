using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(11)]
    public class CustomException : System.ApplicationException
    {
        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [Chapter(11)]
    class Exceptions
    {
        public static void Dispatch()
        {
            TestDivide();
            //Func0();
        }

        public static void TestDivide()
        {
            int d1, d2;
            try
            {
                Console.WriteLine("file opened");
                d1 = 5;
                d2 = 0;
                Console.WriteLine("d1/d2={0}", DoDivide(d1, d2));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("divide by zero caught");
                Console.WriteLine("msg: {0}", e.Message);
                Console.WriteLine("link: {0}", e.HelpLink);
                Console.WriteLine("trace: {0}", e.StackTrace);
                Console.WriteLine();
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("arithmetic exception caught");
            }
            catch (CustomException e)
            {
                Console.WriteLine("caught custom: {0}", e.Message);
                if (e.InnerException != null)
                    Console.WriteLine("inner message: {0}", e.InnerException.Message);
            }
            catch
            {
                Console.WriteLine("unknown exception caught");
            }
            finally
            {
                Console.WriteLine("file closed");
            }
        }

        public static double DoDivide(int d1, int d2)
        {
            //if (d2 == 0)
            //{
            //    DivideByZeroException de = new DivideByZeroException();
            //    de.HelpLink = "Help!";
            //    throw de;
            //}
            if (d1 == 0)
                throw new CustomException("why are you dividing zero?");
            try
            {
                return d1 / d2;
            }
            catch (Exception e)
            {
                throw new CustomException("Oops", e);
            }
        }

        public static void Func0()
        {
            Console.WriteLine("Enter Main...");
            Func1();
            Console.WriteLine("Exit Main...");
        }

        public static void Func1()
        {
            Console.WriteLine("Enter Func1...");
            try
            {
                Console.WriteLine("Entering Try");
                Func2();
                Console.WriteLine("Exiting Try");
            }
            catch
            {
                Console.WriteLine("Exception handled.");
            }
            Console.WriteLine("Exit Func1...");
        }

        public static void Func2()
        {
            Console.WriteLine("Enter Func2...");
            //try
            //{
            //    Console.WriteLine("Entering Try");
            throw new System.Exception();
            //    Console.WriteLine("Exiting Try");
            //}
            //catch
            //{
            //    Console.WriteLine("Exception handled.");
            //}
            Console.WriteLine("Exit Func2...");
        }
    }
}
