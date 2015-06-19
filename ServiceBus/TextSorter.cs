using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    class TextSorter : IPlugIn
    {
        bool IPlugIn.Alive()
        {
            return true;
        }

        bool IPlugIn.Start()
        {
            return true;
        }

        bool IPlugIn.Stop()
        {
            return true;
        }

        bool IPlugIn.Pause()
        {
            return true;
        }
    }
}
