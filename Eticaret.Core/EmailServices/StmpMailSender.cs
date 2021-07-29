using Microsoft.Extensions.Configuration;
using Pal.Core.EmailServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Pal.Core.EmailServices.Concrete
{
    public class StmpMailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }
        private StmpOptions _stmpOptions;
        public StmpMailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _stmpOptions = Configuration.GetSection("PanelStmpOptions").Get<StmpOptions>();

        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_stmpOptions.Host, _stmpOptions.Port)
            {
                Credentials = new NetworkCredential(_stmpOptions.Username, _stmpOptions.Password),
                EnableSsl = _stmpOptions.EnableSSL
            };

            return client.SendMailAsync(
                new MailMessage(_stmpOptions.Username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                }
            );
        }
    }
}
