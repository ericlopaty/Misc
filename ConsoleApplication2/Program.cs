using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Number
    {
        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (Number n in GetNumbers(1,10))
                Console.WriteLine("{0}",n.Value);
            Console.ReadLine();
        }

        private static IEnumerable<Number> GetNumbers(int beginning, int ending)
        {
            for (int i = beginning; i < ending; i++)
            {
                var q = new Number();
                q.Value = i;
                yield return q;
            }
        }
    }
}
