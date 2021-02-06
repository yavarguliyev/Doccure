using AutoMapper;
using Core.DTOs.Auth;
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
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userService.LoginAsync(model.Email, model.Password);

            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = _mapper.Map<User>(model);
            var mapped = _mapper.Map<UserDTO>(await _userService.CreateAsync(user, UserRole.Patient));

            return Ok(mapped);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO model)
        {
            var user = await _userService.GetByEmailAsync(model.Email);

            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model, [FromQuery] string token)
        {
            var user = new User();
            user.Password = model.Password;
            var userToBeUpdated = await _userService.GetByTokenAsync(token);
            var mapped = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user));

            return Ok(mapped);
        }
    }
}