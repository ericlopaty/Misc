using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeckerQ1
{
    delegate int MyDel();

    class MyClass
    {
        int IntValue = 5;
        public int Add2() { IntValue += 2; return IntValue; }
        public int Add3() { IntValue += 3; return IntValue; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            MyDel myDel=null;    // = mc.Add2;
            myDel += mc.Add3;
            myDel += mc.Add2;
            Console.WriteLine("Value: {0}", myDel());
            Console.ReadLine();
        }
    }
}
