using AutoMapper;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Common;
using Core.Services.Data;
using Data.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Account
{
    public class AuthController : BaseApiController
    {
        #region auth
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IActivityService _activityService;

        public AuthController(IMapper mapper,
                              IUserService userService,
                              IActivityService activityService)
        {
            _mapper = mapper;
            _userService = userService;
            _activityService = activityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var loggedIn = await _userService.LoginAsync(model.Email, model.Password);
            var user = await _userService.GetAsync(loggedIn.Id);

            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = _mapper.Map<User>(model);
            user.ConfirmToken = Guid.NewGuid().ToString();
            var mapped = _mapper.Map<UserDTO>(await _userService.CreateAsync(user, UserRole.Patient));
            var createdUser = await _userService.GetByConfirmTokenAsync(mapped.ConfirmToken);

            var url = string.Empty;

            switch (createdUser.Role)
            {
                case UserRole.Doctor:
                    url = $"/doctors/auth/confirm-email/{createdUser.ConfirmToken}";
                    break;
                case UserRole.Patient:
                    url = $"/patients/auth/confirm-email/{createdUser.ConfirmToken}";
                    break;
                default:
                    throw new RestException(HttpStatusCode.BadRequest, new { user = "Make sure you have valid role for resseting your account." });
            }

            await _activityService.SendEmail(createdUser, 
                "Complete register process", 
                createdUser.Fullname + "'s register account", 
                "To complete register process click to the button!", 
                true, 
                "Complete register process", 
                url);

            return Ok(new
            {
                message = "Confirm your email please."
            });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var userToBeUpdated = await _userService.GetByConfirmTokenAsync(token);
            var user = new User();
            user.ConfirmToken = null;

            var response = await _userService.UpdateAsync(userToBeUpdated, user);

            return Ok(new
            {
                message = "Email confirmed.",
                response = response
            });
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDTO model)
        {
            var userToBeUpdated = await _userService.GetByEmailAsync(model.Email);
            var user = new User();
            user.InviteToken = Guid.NewGuid().ToString();
            var response = await _userService.UpdateAsync(userToBeUpdated, user);

            var url = string.Empty;

            switch (response.Role)
            {
                case UserRole.Doctor:
                    url = $"/doctors/auth/reset-password/{response.InviteToken}";
                    break;
                case UserRole.Patient:
                    url = $"/patients/auth/reset-password/{response.InviteToken}";
                    break;
                default:
                    throw new RestException(HttpStatusCode.BadRequest, new { user = "Make sure you have valid role for resseting your account." });
            }

            await _activityService.SendEmail(response, "Complete reset process", response.Fullname + "'s password reset", "To complete reset process click to the button!", true, "Complete reset process", url);

            return Ok(new
            {
                message = "Email sent."
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model, [FromQuery] string token)
        {
            var user = new User();
            user.Password = model.Password;
            user.InviteToken = null;
            var userToBeUpdated = await _userService.GetByInviteTokenAsync(token);
            var mapped = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user));

            return Ok(mapped);
        }
        #endregion
    }
}