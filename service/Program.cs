using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{    
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress=new Uri("http://localhost:8000/ServiceModelSamples/Service");
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("Service Ready");
                Console.WriteLine("Press <ENTER> to terminate.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException cx)
            {
                Console.WriteLine("Service Exception: {0}", cx.Message);
                selfHost.Abort();
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: {0}", x.Message);
                selfHost.Abort();
            }
            Console.WriteLine("Service Closed");
            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }
    }
}
