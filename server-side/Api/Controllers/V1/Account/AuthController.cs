using AutoMapper;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Account
{
    public class AuthController : BaseApiController
    {
        #region auth functionalities
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper,
                              IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userService.LoginAsync(model.Email, model.Password);
            var response = _mapper.Map<UserDTO>(await _userService.GetAsync(user.Id));

            return Ok(new
            {
                message = "Success!",
                response = response
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            await _userService.CreateAsync(_mapper.Map<User>(model), UserRole.Patient);

            return Ok(new
            {
                message = "Confirm your email please!"
            });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var response = _mapper.Map<UserDTO>(await _userService.ConfirmTokenAsync(token));

            return Ok(new
            {
                message = "User confirmed!",
                response = response
            });
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDTO model)
        {
            var user = await _userService.GetByEmailAsync(model.Email);
            await _userService.InviteTokenAsync(user.InviteToken);

            return Ok(new
            {
                message = "Email sent!"
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model, [FromQuery] string token)
        {
            var user = await _userService.GetByInviteTokenAsync(token);
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(user.Id, model.Password, model.ConfirmPassword, null));

            return Ok(new
            {
                message = "Password reseted!",
                response = response
            });
        }
        #endregion
    }
}