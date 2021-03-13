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
        private IUserService _userService;
        private IAuth _auth;

        protected IMapper mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected IUserService userService => _userService ??= HttpContext.RequestServices.GetService<IUserService>();
        protected IAuth auth => _auth ??= HttpContext.RequestServices.GetService<IAuth>();
    }
}