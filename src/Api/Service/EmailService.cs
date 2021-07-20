using Api.Service;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace Api.Service
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string Body)
        {
            //try
            //{
            var mimeMessage = new MimeMessage();

            mimeMessage.To.Add(new MailboxAddress("no-reply@alupigus.online", "no-reply@alupigus.online"));
            mimeMessage.From.Add(new MailboxAddress("Alupigus Online", "no-reply@alupigus.online"));
            mimeMessage.Subject = "Welcome";
            mimeMessage.Body = new BodyBuilder { HtmlBody = "<html>" + Body + "</html>", TextBody = Body }.ToMessageBody();

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.ServerCertificateValidationCallback = (_sender, certificate, certChainType, errors) => true;
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Connect("mail.privateemail.com", 465, SecureSocketOptions.SslOnConnect);
                smtpClient.Authenticate("no-reply@alupigus.online", "IHateAlicia");
                smtpClient.Send(mimeMessage);
            }

            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}