using AutoMapper;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Account
{
    public class AuthController : BaseApiController
    {
        #region auth
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
            var loggedIn = await _userService.LoginAsync(model.Email, model.Password);

            return Ok(_mapper.Map<UserDTO>(await _userService.GetAsync(loggedIn.Id)));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = _mapper.Map<User>(model);
            user.ConfirmToken = Guid.NewGuid().ToString();
            await _userService.CreateAsync(user, UserRole.Patient);

            return Ok(new { message = "Confirm your email please." });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var userToBeUpdated = await _userService.GetByConfirmTokenAsync(token);
            var user = new User();
            user.ConfirmToken = null;

            return Ok(new
            {
                message = "Email confirmed.",
                response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user))
            }); ;
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDTO model)
        {
            var userToBeUpdated = await _userService.GetByEmailAsync(model.Email);
            var user = new User();
            user.InviteToken = Guid.NewGuid().ToString();
            await _userService.UpdateAsync(userToBeUpdated, user);

            return Ok(new { message = "Email sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model, [FromQuery] string token)
        {
            var user = new User();
            user.Password = model.Password;
            user.InviteToken = null;

            return Ok(_mapper.Map<UserDTO>(await _userService.UpdateAsync(await _userService.GetByInviteTokenAsync(token), user)));
        }
        #endregion
    }
}