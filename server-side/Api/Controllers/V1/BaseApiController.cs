﻿using Api.Libs;
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

        private IBlogService _blogService;
        private ISettingService _settingService;
        private ISettingPhotoService _settingPhotoService;
        private ISocialMediaService _socialMediaService;
        private IPrivacyService _privacyService;
        private ITermService _termService;

        protected IMapper mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

        protected IAuth auth => _auth ??= HttpContext.RequestServices.GetService<IAuth>();

        protected IUserService userService => _userService ??= HttpContext.RequestServices.GetService<IUserService>();
        
        protected IBlogService blogService => _blogService ??= HttpContext.RequestServices.GetService<IBlogService>();
        protected ISettingService settingService => _settingService ??= HttpContext.RequestServices.GetService<ISettingService>();
        protected ISettingPhotoService settingPhotoService => _settingPhotoService ??= HttpContext.RequestServices.GetService<ISettingPhotoService>();
        protected ISocialMediaService socialMediaService => _socialMediaService ??= HttpContext.RequestServices.GetService<ISocialMediaService>();
        protected IPrivacyService privacyService => _privacyService ??= HttpContext.RequestServices.GetService<IPrivacyService>();
        protected ITermService termService => _termService ??= HttpContext.RequestServices.GetService<ITermService>();
    }
}