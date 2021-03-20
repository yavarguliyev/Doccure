using Core.Services.Rest;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Services.Rest
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(string email, string name, object data)
        {
            var client = new SendGridClient(_configuration["SendGrid:Key"]);

            var message = new SendGridMessage();

            message.SetFrom(_configuration["SendGrid:Email"], _configuration["SendGrid:Url"]);
            message.AddTo(email, name);
            message.SetTemplateId(_configuration["SendGrid:Id"]);
            message.SetTemplateData(data);

            await client.SendEmailAsync(message);
        }
    }
}