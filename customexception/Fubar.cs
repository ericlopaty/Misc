using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace customexception
{
    class FubarException : ApplicationException
    {
        public string MoreInfo;

        public FubarException(string msg, string moreInfo)
        {
            MoreInfo = moreInfo;
        }
    }

    class Fubar
    {
        public static void Method(int i)
        {
            if (i % 2 != 0)
                throw new FubarException("I'm throwing an exception", "with more info");
        }
    }
}
