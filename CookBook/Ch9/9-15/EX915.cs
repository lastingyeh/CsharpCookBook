using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace CookBook.Ch9
{
    public static class EX915
    {
        public static async void SendMail()
        {
            string from = "authors@oreilly.com";
            string to = "authors@oreilly.com";

            MailMessage attachmentMessage = new MailMessage(from, to);
            attachmentMessage.Subject = "Hi there!";
            attachmentMessage.Body = "Check out this cool code!";

            attachmentMessage.IsBodyHtml = false;

            string pathToCode = @"..\..\09_NetworkingAndWeb.cs";
            Attachment attachment = new Attachment(pathToCode,
                MediaTypeNames.Application.Octet);
            attachmentMessage.Attachments.Add(attachment);

            // just send text
            MailMessage textMessage = new MailMessage("authors@oreilly.com",
                "authors@oreilly.com", "Me again",
                "You need therapy, talking to yourself is one thing but " +
                "writing code to send email is a whole other thing...");

            using(SmtpClient client = new SmtpClient("SMTPSEVER", 999))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("SMTP_USERNAME", "SMTP_PASSWORD");

                await client.SendMailAsync(attachmentMessage);
            }
        }
    }
}
