using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    public static class Roman
    {
        public static string ToRoman(int i)
        {
            object[,] groups = new object[,] {
                {1000,"M"},{900,"CM"},{500,"D"},{400,"CD"},{100,"C"},{90, "XC"},{50, "L"},
                {40, "XL"},{10, "X"},{9, "IX"},{5, "V"},{4, "IV"},{1, "I"}};
            StringBuilder roman = new StringBuilder();
            while (i > 0)
            {
                for (int j = 0; j < 13; j++)
                {
                    if ((int)groups[j,0] <= i)
                    {
                        roman.Append((string)groups[j,1]);
                        i -= (int)groups[j,0];
                        break;
                    }
                }
            }
            return roman.ToString();
        }

    }
}
