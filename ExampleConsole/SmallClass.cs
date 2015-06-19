using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    public static class SmallClassTester
    {
        public static void OverrideToString()
        {
            SmallClass s = new SmallClass(5);
            Console.Write(s);
        }
    }

    class SmallClass
    {
        protected int val;

        public SmallClass(int val)
        {
            this.val = val;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", val);
        }
    }
}
