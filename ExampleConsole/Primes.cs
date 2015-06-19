using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class Primes
    {
        public static void CalcPrimes()
        {
            int i = 1000000;
            int c = 0;
            while (i > 0)
            {
                int j = 2;
                bool prime = true;
                while (prime && j <= Math.Sqrt(i))
                {
                    prime = i % j != 0;
                    j += (j == 2 ? 1 : 2);
                }
                if (prime)
                    Console.WriteLine("{0} - {1}", i, ++c);
                i--;
            }
            Console.ReadLine();
        }
    }
}
