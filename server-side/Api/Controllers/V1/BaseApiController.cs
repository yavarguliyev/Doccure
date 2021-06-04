using Api.Libs;
using AutoMapper;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase 
    {
        private IMapper _mapper;
        private IAuth _auth;

        private IUserService _userService;
        private IChatMessageService _chatMessageService;

        private IBlogService _blogService;
        private IDoctorSocialMediaUrlLinkService _urlLinkService;

        private IFeatureService _featureService;
        private ISpecialityService _specialityService;
        private ISettingService _settingService;
        private ISettingPhotoService _settingPhotoService;
        private ISocialMediaService _socialMediaService;
        private IPrivacyService _privacyService;
        private ITermService _termService;

        protected IMapper mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected IAuth auth => _auth ??= HttpContext.RequestServices.GetService<IAuth>();

        protected IUserService userService => _userService ??= HttpContext.RequestServices.GetService<IUserService>();
        protected IChatMessageService chatMessageService => _chatMessageService ??= HttpContext.RequestServices.GetService<IChatMessageService>();
        
        protected IDoctorSocialMediaUrlLinkService urlLinkService => _urlLinkService ??= HttpContext.RequestServices.GetService<IDoctorSocialMediaUrlLinkService>();
        protected IBlogService blogService => _blogService ??= HttpContext.RequestServices.GetService<IBlogService>();
        
        protected IFeatureService featureService => _featureService ??= HttpContext.RequestServices.GetService<IFeatureService>();
        protected ISpecialityService specialityService => _specialityService ??= HttpContext.RequestServices.GetService<ISpecialityService>();
        protected ISettingService settingService => _settingService ??= HttpContext.RequestServices.GetService<ISettingService>();
        protected ISettingPhotoService settingPhotoService => _settingPhotoService ??= HttpContext.RequestServices.GetService<ISettingPhotoService>();
        protected ISocialMediaService socialMediaService => _socialMediaService ??= HttpContext.RequestServices.GetService<ISocialMediaService>();
        protected IPrivacyService privacyService => _privacyService ??= HttpContext.RequestServices.GetService<IPrivacyService>();
        protected ITermService termService => _termService ??= HttpContext.RequestServices.GetService<ITermService>();
    }
}