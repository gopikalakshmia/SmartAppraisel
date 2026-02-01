using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DL_SmartAppraisel.Utilities
{
    public class EmailService 
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            // Configure SMTP client once
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("gopikalakshmia@gmail.com", "Paru123#"),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("gopikalakshmia@gmail.com", "Smart Appraisal"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
