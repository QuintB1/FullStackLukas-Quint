using ChampionLeague.utils.Mail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ChampionLeague.utils.Mail
{
    public class EmailSend : IEmailSend
    {
        private readonly EmailSettings _emailSettings;

        public EmailSend(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage();  // aanmaken van een mail-object
            mail.To.Add(new MailAddress(email));

            mail.From = new MailAddress("lukasdevos2005@gmail.com");  // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            try
            {

                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task SendEmailAttachmentAsync(string to, string subject, string message, byte[] pdfBytes)
        {
            var mail = new MailMessage();  // aanmaken van een mail-object
            mail.To.Add(new MailAddress(to));
            mail.From = new MailAddress("lukasdevos2005@gmail.com");  // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = subject;
            mail.IsBodyHtml = true;

            using var stream = new MemoryStream(pdfBytes);


            mail.Attachments.Add(
                new Attachment(stream, "ticket.pdf", MediaTypeNames.Application.Pdf));

            try
            {

                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private async Task SmtpMailAsync(MailMessage mail)
        {
            using (var smtp = new SmtpClient(_emailSettings.MailServer))
            {
                smtp.Port = _emailSettings.MailPort;
                smtp.EnableSsl = true;
                smtp.Credentials =
                    new NetworkCredential(_emailSettings.Sender,
                                            _emailSettings.Password);
                smtp.UseDefaultCredentials = false;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
