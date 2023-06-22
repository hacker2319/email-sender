using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 7;
                int b = 0;
                Console.WriteLine(a / b);

            }
            catch (Exception e)

            {
                string msg = $"<b>Source</b>: {e.Source} <br/> " +
                             $"<b>Message</b>: {e.Message} <br/> " +
                             $"<b>Stacktrace</b>: {e.StackTrace} <br/>" +
                             $"<b>Time</b>: {DateTime.UtcNow}";

               send(msg);
            }



        }

        static void send(string message)
        {
            MimeMessage email = new MimeMessage();

            string
                your_name = "hacker2319",
                your_email = "trashedsmile.you@gmail.com",
                recipient_name = "myself",
                recipient_email = "trashedsmile.you@gmail.com",
                subject = "error happend",
                smtp_address = "smtp.gmail.com",
                auth_username = "trashedsmile.you@gmail.com",
                auth_password = "tgvpgpdbuqtdbdvc";

            int smtp_port = 587;
            bool use_ssl = false;

            email.From.Add(new MailboxAddress(your_name, your_email));
            email.To.Add(new MailboxAddress(recipient_name, recipient_email));

            email.Subject = subject;



            // plain text with attachment
            var builder = new BodyBuilder()
            {
                HtmlBody = message,
            };
            builder.Attachments.Add(@"C:\Users\trash\OneDrive\Desktop\Untitled.png");

            email.Body = builder.ToMessageBody();

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Connect(smtp_address, smtp_port, use_ssl);

                smtp.Authenticate(auth_username, auth_password);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }





    }
}
