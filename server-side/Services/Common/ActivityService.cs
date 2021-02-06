using Core.Models;
using Core.Services.Common;
using Core.Services.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Services.Common
{
    public class ActivityService : IActivityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public ActivityService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IEmailService emailService)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _emailService = emailService;
        }

        #region email
        public async Task SendEmail(User user, string purpose, string titleText, string bodytext, bool btnActivve, string btnText, string url)
        {
            await _emailService.Send(user.Email, user.Fullname,
                                         _configuration["WebMaster:TemplateId"],
                                         new
                                         {
                                             subject = "Welcome to Doccure.com",
                                             purpose = purpose,
                                             title = "Welcome to Doccure.com",
                                             titletext = titleText,
                                             bodytext = bodytext,
                                             btn = new
                                             {
                                                 active = btnActivve,
                                                 text = btnText,
                                                 url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{url}"
                                             }
                                         });
        }
        #endregion
    }
}