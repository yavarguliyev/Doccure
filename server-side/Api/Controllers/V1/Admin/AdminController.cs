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
        public IActionResult Get()
        {
            if (auth.Admin == null) return Unauthorized();
            return Ok(mapper.Map<UserDTO>(auth.Admin));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserProfileUpdateDTO model)
        {
            if (auth.Admin == null) return Unauthorized();
            var userToBeUpdated = await userService.GetAsync(auth.Admin.Id);
            var response = await userService.UpdateAsync(userToBeUpdated, mapper.Map<User>(model));
            return Ok(new { message = "Profile successfully updated!", response = response });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
        {
            if (auth.Admin == null) return Unauthorized();
            var response = await userService.UpdateAsync(auth.Admin.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            return Ok(new { message = "Password successfully updated!", response = response });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (auth.Admin == null) return Unauthorized();
            var image = await userService.PhotoUpload(auth.Admin.Id, file);
            return Ok(new { message = "Photo uploaded!", image });
        }
        #endregion
    }
}