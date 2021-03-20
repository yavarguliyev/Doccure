using Core.Models;
using Core.Services.Common;
using Core.Services.Rest;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services.Common
{
    public class ActivityService : IActivityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;

        public ActivityService(IHttpContextAccessor httpContextAccessor,
                               IEmailService emailService)
        {
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
        }

        #region email
        public async Task SendEmail(User user, string purpose, string title, string body, bool btnActive, string url)
        {
            await _emailService.Send(user.Email, user.Fullname, new
            {
                subject = "Welcome to Doccure.com",
                purpose = purpose,
                title = "Welcome to Doccure.com",
                titletext = title,
                bodytext = body,
                btn = new
                {
                    active = btnActive,
                    text = "Click Here",
                    url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{url}"
                }
            });
        }
        #endregion
    }
}