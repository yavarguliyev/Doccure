using Api.DTOs.Auth;
using Api.Resources.Auth;
using AutoMapper;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.V1.Account
{
    public class AuthController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource model)
        {
            var user = await _userService.LoginAsync(model.Email, model.Password);
            var mapped = _mapper.Map<UserDTO>(user);

            return Ok(mapped);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = _mapper.Map<RegisterDTO, User>(model);
            var mapped = _mapper.Map<User, UserDTO>(await _userService.CreateAsync(user, UserRole.Patient));

            return Ok(mapped);
        }
    }
}