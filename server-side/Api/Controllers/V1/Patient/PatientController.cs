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
            if (Auth.Patient == null) return Unauthorized();
            return Ok(Mapper.Map<UserDTO>(Auth.Patient));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserProfileUpdateDTO model)
        {
            if (Auth.Patient == null) return Unauthorized();
            var userToBeUpdated = await UserService.GetAsync(Auth.Patient.Id);
            var response = await UserService.UpdateAsync(userToBeUpdated, Mapper.Map<User>(model));
            return Ok(new { message = "Profile successfully updated!", response });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
        {
            if (Auth.Patient == null) return Unauthorized();
            var response = await UserService.UpdateAsync(Auth.Patient.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            return Ok(new { message = "Password successfully updated!", response });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (Auth.Patient == null) return Unauthorized();
            var image = await UserService.PhotoUploadAsync(Auth.Patient.Id, file);
            return Ok(new { message = "Photo uploaded!", image });
        }
        #endregion
    }
}