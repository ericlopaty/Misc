using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace pinger
{
    public class pinger
    {
        public static void Main (string[] args)
        {
            try
            {
                if (args.Length < 1)
                    return;
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                while (true)
                {
                    Console.Clear();
                    Console.Title = "Net: Query";
                    Console.WriteLine("Ping {0} sent at {1}", args[0], DateTime.Now.ToLongTimeString());
                    PingReply reply = pingSender.Send(args[0], timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.Title = "Net: OK";
                        Console.WriteLine("Address: {0}", reply.Address.ToString());
                        Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    }
                    else
                    {
                        Console.Title = "Net: Error";
                    }
                    Thread.Sleep(30000);
                }
            }
            catch (Exception x)
            {
                Console.Title = "Fatal Error";
                Console.WriteLine("Fatal Error: {0}", x.Message);
            }
        }
    }
}