using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Unrelated
{
    class SeparateClass
    {
        public static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void DoSomething(int x)
        {
            //_log.InfoFormat("Logging value {0}", x);
            Exception x2 = new Exception("Inner Exception! Inner Exception!");
            throw new Exception("Exception! Exception!", x2);
        }
    }
}
