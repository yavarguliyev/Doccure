using Api.Libs;
using AutoMapper;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Core.Helpers;
using Api.Extensions;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase 
    {
        #region services
        private IMapper _mapper;
        private IAuth _auth;

        private IUserService _userService;
        private IChatMessageService _chatMessageService;
        private IChatService _chatService;

        private IBlogService _blogService;
        private IDoctorSocialMediaUrlLinkService _urlLinkService;

        private IFeatureService _featureService;
        private ISpecialityService _specialityService;
        private ISettingService _settingService;
        private ISettingPhotoService _settingPhotoService;
        private ISocialMediaService _socialMediaService;
        private IPrivacyService _privacyService;
        private ITermService _termService;

        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected IAuth Auth => _auth ??= HttpContext.RequestServices.GetService<IAuth>();

        #endregion

        #region
        protected IUserService UserService => _userService ??= HttpContext.RequestServices.GetService<IUserService>();
        protected IChatMessageService ChatMessageService => _chatMessageService ??= HttpContext.RequestServices.GetService<IChatMessageService>();
        protected IChatService ChatService => _chatService ??= HttpContext.RequestServices.GetService<IChatService>();
        
        protected IDoctorSocialMediaUrlLinkService UrlLinkService => _urlLinkService ??= HttpContext.RequestServices.GetService<IDoctorSocialMediaUrlLinkService>();
        protected IBlogService BlogService => _blogService ??= HttpContext.RequestServices.GetService<IBlogService>();
        
        protected IFeatureService FeatureService => _featureService ??= HttpContext.RequestServices.GetService<IFeatureService>();
        protected ISpecialityService SpecialityService => _specialityService ??= HttpContext.RequestServices.GetService<ISpecialityService>();
        protected ISettingService SettingService => _settingService ??= HttpContext.RequestServices.GetService<ISettingService>();
        protected ISettingPhotoService SettingPhotoService => _settingPhotoService ??= HttpContext.RequestServices.GetService<ISettingPhotoService>();
        protected ISocialMediaService SocialMediaService => _socialMediaService ??= HttpContext.RequestServices.GetService<ISocialMediaService>();
        protected IPrivacyService PrivacyService => _privacyService ??= HttpContext.RequestServices.GetService<IPrivacyService>();
        protected ITermService TermService => _termService ??= HttpContext.RequestServices.GetService<ITermService>();
        #endregion

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            if (result.IsSuccess && result.Value == null) return NotFound();
            return BadRequest(result.Error);
        }
        
        protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                Response.AddPagination(result.Value.CurrentPage, result.Value.PageSize,
                    result.Value.TotalCount, result.Value.TotalPages);
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest(result.Error);
        }
    }
}