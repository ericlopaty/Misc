using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourPics
{
    class Program
    {
        StringBuilder letters;
        int length;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run(args);
        }

        private void Run(string[] args)
        {
            length = int.Parse(args[0]);
            letters = new StringBuilder(args[1]);
            Show(letters, new StringBuilder(), 0);
        }

        private void Show(StringBuilder letters, StringBuilder word, int index)
        {
            if (index == length)
            {
                Console.WriteLine(word);
                return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == '-')
                    continue;
                StringBuilder newWord = new StringBuilder(word.ToString());
                newWord.Append(letters[i]);
                StringBuilder passThrough = new StringBuilder(letters.ToString());
                passThrough[i] = '-';
                Show(passThrough, newWord, index + 1);
            }
        }
    }
}
