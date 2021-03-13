using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Account
{
    public class AuthController : BaseApiController
    {
        #region auth functionalities
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            return Ok(await userService.LoginAsync(model.Email, model.Password));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            await userService.CreateAsync(mapper.Map<User>(model), UserRole.Patient);
            return Ok(new { message = "Confirm your email please!" });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            var response = await userService.ConfirmTokenAsync(token);
            return Ok(new { message = "User confirmed!", response });
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO model)
        {
            await userService.InviteTokenAsync(await userService.GetByEmailAsync(model.Email));
            return Ok(new { message = "Email sent!" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO model, string token)
        {
            var user = await userService.GetByInviteTokenAsync(token);
            var response = await userService.UpdateAsync(user.Id, model.Password, model.ConfirmPassword, null);
            return Ok(new { message = "Password reseted!", response });
        }
        #endregion
    }
}