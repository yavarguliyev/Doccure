using Core.DTOs.Auth;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class AdminController : BaseApiController
    {
        #region admin profile functionalities
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (Auth.Admin == null) return Unauthorized();
            return Ok(Mapper.Map<UserDTO>(await UserService.GetAsync(Auth.Admin.Id)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserProfileUpdateDTO model)
        {
            if (Auth.Admin == null) return Unauthorized();
            var userToBeUpdated = await UserService.GetAsync(Auth.Admin.Id);
            var response = await UserService.UpdateAsync(userToBeUpdated, Mapper.Map<User>(model));
            return Ok(new { message = "Profile successfully updated!", response });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
        {
            if (Auth.Admin == null) return Unauthorized();
            var response = await UserService.UpdateAsync(Auth.Admin.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            return Ok(new { message = "Password successfully updated!", response });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (Auth.Admin == null) return Unauthorized();
            var image = await UserService.PhotoUploadAsync(Auth.Admin.Id, file);
            return Ok(new { message = "Photo uploaded!", image });
        }
        #endregion
    }
}