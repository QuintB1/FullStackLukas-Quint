using ChampionLeague.utils.Mail.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        public EmailSend(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage();  // aanmaken van een mail-object
            mail.To.Add(new MailAddress(email));

            mail.From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName);  // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            try
            {
                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SendEmailAttachmentAsync(string to, string subject, string message, List<byte[]> pdfFiles)
        {
            var mail = new MailMessage();  // aanmaken van een mail-object
            mail.To.Add(new MailAddress(to));
            mail.From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName);  // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            int counter = 1;

            foreach (var pdfBytes in pdfFiles)
            {
                var stream = new MemoryStream(pdfBytes);

                mail.Attachments.Add(
                    new Attachment(stream, $"ticket_{counter}.pdf", MediaTypeNames.Application.Pdf)
                );

                counter++;
            }

            try
            {
                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
