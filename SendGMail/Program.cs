using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SendGMail
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress fromAddress = new MailAddress("llchorale@gmail.com", "Lakeland Chorale");
            MailAddress toAddress = new MailAddress("ericlopaty@gmail.com");
            const string fromPassword = "chipdalton";
            const string subject = "Test Subject";
            const string body = "<html><body font=\"courier new\">this is courier new font text<br>A second line</body></html>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress))
            {
                message.Subject=subject;
                message.Body=body;
                smtp.Send(message);
            }
        }
    }
}




