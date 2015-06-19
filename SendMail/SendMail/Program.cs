using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("SMTP (mail.r2k.int): ");
                string s = Console.ReadLine();
                string server = (s.Length == 0 ? "mail.r2k.com" : s);

                Console.Write("          Port (25): ");
                s = Console.ReadLine();
                int port = (s.Length == 0) ? 25 : int.Parse(s);

                Console.WriteLine();

                Console.Write("   From: ");
                string fromAddress = Console.ReadLine();

                Console.Write("     To: ");
                string toAddress = Console.ReadLine();

                Console.Write("Subject: ");
                string subject = Console.ReadLine();

                Console.Write("   Body: ");
                string body = Console.ReadLine();

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = server;
                    smtp.Port = port;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 20000;
                    //smtp.EnableSsl = true;
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new NetworkCredential(fromMailAddress.Address, "");

                    var fromMailAddress = new MailAddress(fromAddress);
                    var toMailAddress = new MailAddress(toAddress);

                    using (var message = new MailMessage())
                    {
                        message.From = fromMailAddress;
                        message.To.Add(toMailAddress);
                        message.Subject = subject;
                        message.Body = body;
                        smtp.Send(message);
                    }
                    Console.WriteLine("Message Sent");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("SMTP Error: " + ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine("Inner Error: " + ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
