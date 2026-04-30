using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionLeague.utils.Mail.Interfaces
{
    public interface IEmailSend
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAttachmentAsync(string email, string subject, string message, byte[] pdfBytes);
    }
}
