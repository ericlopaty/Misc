using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress epAddress = new EndpointAddress("http://localhost:8000/ServiceModelSamples/Service/CalculatorService");
            CalculatorClient client = new CalculatorClient(new WSHttpBinding(), epAddress);
            double n1 = 123.4;
            double n2 = 567.8;
            Console.WriteLine("{0} + {1} = {2}",n1,n2,client.Add(n1,n2));
            Console.WriteLine("{0} - {1} = {2}",n1,n2,client.Subtract(n1,n2));
            Console.WriteLine("{0} * {1} = {2}",n1,n2,client.Multiply(n1,n2));
            Console.WriteLine("{0} / {1} = {2}",n1,n2,client.Divide(n1,n2));
            client.Close();
            Console.ReadLine();

            ServiceReference1.CalculatorClient calculator = new client.ServiceReference1.CalculatorClient(new WSHttpBinding(), epAddress);
            Console.WriteLine("{0} + {1} = {2}", 4, 5, calculator.Add(4, 5));
            
        }
    }
}
