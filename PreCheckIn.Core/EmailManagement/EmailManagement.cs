using System;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace PreCheckIn.Core.EmailManagement
{
    public class EmailManagement : IEmailManagement
    {
        private IConfiguration _configuration;

        public EmailManagement(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendConfirmationEmail(string to, string body)
        {
            try
            {
                var smtpClient = new SmtpClient(_configuration["Email:Host"])
                {
                    Port = int.Parse(_configuration["Email:Port"]),
                    Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Email:From"]),
                    Subject = "Booking confirmation email",
                    Body = SetEmailTemplate(body),
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        private string SetEmailTemplate(string text)
        {
            string html = "<p>"+text+"</p>";
            return html;
        }
    }
}
