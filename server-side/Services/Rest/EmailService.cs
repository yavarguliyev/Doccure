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

        public async Task Send(string email, string name, string templateId, object data)
        {
            var client = new SendGridClient(_configuration["WebMaster:SendGridKey"]);

            var message = new SendGridMessage();

            message.SetFrom("no-reply@doccure.com", "doccure.com");
            message.AddTo(email, name);
            message.SetTemplateId(templateId);
            message.SetTemplateData(data);

            await client.SendEmailAsync(message);
        }
    }
}