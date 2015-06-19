using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Toolbox;

namespace BulkMessenger
{
    class Program
    {
        private static Toolbox.Channel channel = null;
        private static System.Timers.Timer timer;
        private static string thisSide, thatSide;
        private static int limit, sent = 0, received = 0, interval;
        private static object sync = new object();
        private static string sentFile, receivedFile;

        static void Main(string[] args)
        {

            // parse the input parameters
            Toolbox.ParseArgs parms = new Toolbox.ParseArgs(args);
            limit = int.Parse(parms.GetValue("c","0"));
            interval = int.Parse(parms.GetValue("i","0"));
            thisSide = parms.GetValue("me","");
            thatSide = parms.GetValue("you","");

            // initialize the files
            sentFile = thisSide + ".sent.txt";
            if (File.Exists(sentFile)) File.Delete(sentFile);
            receivedFile = thisSide + ".received.txt";
            if (File.Exists(receivedFile)) File.Delete(receivedFile);
            
            // create the channel instance
            channel = new Channel(thisSide, thatSide, null);
            channel.Notify += new Channel.ChannelEventHandler(channel_Notify);
            
            // create the send timer instance
            timer = new System.Timers.Timer();
            timer.AutoReset = false;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            
            // wait to begin
            Console.Clear();
            Console.Write("Press ENTER to start.");
            Console.ReadLine();
            Console.Clear();
            
            // start the timer
            timer.Interval = interval;
            timer.Enabled = true;
            
            // wait
            Console.ReadLine();
            
            // cleanup
            channel.Dispose();
            timer.Dispose();
        }

        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // send a message
            SendMessage();
            
            // enable the timer for the next send
            timer.Enabled = (sent < limit);
        }

        private static void SendMessage()
        {
            // bump the sent counter
            sent++;
            
            // build a random message
            string msg = BuildMsg(sent);
            
            // update the console display
            UpdateConsole(0, string.Format("    Sent: {0,7:#,##0} ({1,2:#0}%)", sent, Math.Floor((double)sent / limit * 100)));
            
            // send the message and also append it to the file
            channel.Send(msg);
            File.AppendAllText(sentFile, msg + "\n");
            
            // update console title
            if (sent % 10 == 0)
                Console.Title = string.Format("Sent {0:#,##0} ({1} to {2})", sent, thisSide, thatSide);
        }

        private static string BuildMsg(int n)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            string alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder msg = new StringBuilder();
            msg.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><PipeMessage>");
            msg.Append(string.Format("<sequence>{0}</sequence><data>", n));
            for (int i = 0; i < r.Next(100, 301); i++)
                msg.Append(alphas[r.Next(0, alphas.Length)]);
            msg.Append("</data></PipeMessage>");
            return msg.ToString();
        }

        private static void channel_Notify(object sender, Channel.ChannelEventArgs e)
        {
            // bump the received counter
            received++;
            
            // update the console display
            UpdateConsole(1,string.Format("Received: {0,7:#,##0}", received));
            
            // append the received data to the file
            File.AppendAllText(receivedFile, e.Data + "\n");
        }

        private static void UpdateConsole(int top, string message)
        {
            lock (sync)
            {
                Console.SetCursorPosition(0, top);
                Console.Write(message);
            }
        }
    }
}
