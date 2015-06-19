using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    class Global
    {
        private static Logger log;
        private static List<IPlugIn> robots;

        static Global()
        {
            robots = new List<IPlugIn>();
        }
        
        public static Logger Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
            }
        }

    }
}
