using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    interface IPlugIn
    {
        bool Start();
        bool Stop();
        bool Pause();
        bool Alive();
    }
}
