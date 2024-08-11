using Application.Abstractions.Email;
using Application.Models.Email;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using MimeKit.Text;
using MailKit.Net.Smtp;



namespace Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void SendEmail(EmailDto request)
        {


            //Create email object
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));

            email.To.Add(MailboxAddress.Parse(request.To));

            email.Subject = request.Subject;

            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
            ///
            
            //Open connection, retrive data from appsettings.
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

           
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            //send, disconnect.
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
