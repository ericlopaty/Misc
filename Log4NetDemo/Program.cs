using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetDemo
{
    class Program
    {
        public static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            _log.Info("==========[ Startup  ]==========");
            try
            {
                _log.Debug("Start of Try block");
                // do some work
                using (log4net.ThreadContext.Stacks["NDC"].Push("context"))
                {
                    _log.Info("Message - 1");
                    using (log4net.ThreadContext.Stacks["NDC"].Push("context2"))
                    {
                        _log.Info("Message - 2");
                    }
                    Unrelated.SeparateClass sc = new Unrelated.SeparateClass();
                    sc.DoSomething(666);
                    _log.Info("Message - 3");
                }
                _log.Info("Message - 4");
                _log.Debug("End of Try block");
            }
            catch (Exception ex)
            {
                _log.Error("Error caught", ex);
            }
            Pause("Done");
            _log.Info("==========[ Shutdown ]==========");
        }

        public static void Pause(string message)
        {
            Console.Write(message);
            Console.ReadLine();
        }
    }
}
