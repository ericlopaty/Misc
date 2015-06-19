using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p=new Program();
            p.Example1();
            Console.ReadLine();
        }

        void Example1()
        {
            string sentence = "The quick brown fox jumped over the lazy dog's back";
            string[] words = sentence.Split(' ');

            var query = from word in words
                group word.ToUpper() by word.Length
                into gr
                orderby gr.Key
                select new {Length = gr.Key, Words = gr};

            var query2 = words.
                GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new {Length = g.Key, Words = g}).
                OrderBy(o => o.Length);

            foreach (var obj in query)
            {
                Console.WriteLine("Words of length {0}:", obj.Length);
                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }
        }
    }
}
