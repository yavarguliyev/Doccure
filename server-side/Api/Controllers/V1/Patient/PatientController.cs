using Core.DTOs.Auth;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Patient
{
    public class PatientController : BaseApiController
    {
        #region patient functionalities
        [HttpGet]
        public IActionResult Get()
        {
            if (auth.Patient == null) return Unauthorized();
            return Ok(mapper.Map<UserDTO>(auth.Patient));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserProfileUpdateDTO model)
        {
            if (auth.Patient == null) return Unauthorized();
            var userToBeUpdated = await userService.GetAsync(auth.Patient.Id);
            var response = await userService.UpdateAsync(userToBeUpdated, mapper.Map<User>(model));
            return Ok(new { message = "Profile successfully updated!", response = response });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
        {
            if (auth.Patient == null) return Unauthorized();
            var response = await userService.UpdateAsync(auth.Patient.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            return Ok(new { message = "Password successfully updated!", response = response });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (auth.Patient == null) return Unauthorized();
            var image = await userService.PhotoUpload(auth.Patient.Id, file);
            return Ok(new { message = "Photo uploaded!", image });
        }
        #endregion
    }
}