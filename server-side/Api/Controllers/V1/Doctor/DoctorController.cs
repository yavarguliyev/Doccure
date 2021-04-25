using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.Enum;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Doctor
{
    public class DoctorController : BaseApiController
    {
        #region patient
        [HttpGet("patients/appointment")]
        public async Task<IActionResult> GetPatientsAppointment()
        {
            if (auth.Doctor == null) return Unauthorized();
            return Ok(mapper.Map<IEnumerable<UserDTO>>(await userService.GetAsync(UserRole.Patient, null)));
        }

        [HttpGet("patient/{slug}")]
        public async Task<IActionResult> GetPatientBySlug(string slug)
        {
            if (auth.Doctor == null) return Unauthorized();
            return Ok(mapper.Map<UserDTO>(await userService.GetByAsync(slug)));
        }
        #endregion

        #region doctor
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (auth.Doctor == null) return Unauthorized();
            return Ok(mapper.Map<UserDTO>(await userService.GetAsync(auth.Doctor.Id)));
        }

        [HttpGet("social-media-url")]
        public async Task<IActionResult> GetDoctorSocialMedialUrl()
        {
            if (auth.Doctor == null) return Unauthorized();
            return Ok(mapper.Map<DoctorSocialMediaUrlLinkDTO>(await urlLinkService.GetAsync(auth.Doctor.Id)));
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<IActionResult> Register(NewDoctorModifyDTO model, string token)
        {
            var userToBeUpdated = await userService.GetAsync(token);
            var response = await userService.UpdateAsync(userToBeUpdated, mapper.Map<User>(model));
            return Ok(new { message = "Registration successfully completed!", response });
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> Update(UserProfileUpdateDTO model)
        {
            if (auth.Doctor == null) return Unauthorized();
            var userToBeUpdated = await userService.GetAsync(auth.Doctor.Id);
            var response = await userService.UpdateAsync(userToBeUpdated, mapper.Map<User>(model));

            return Ok(new { message = "Profile info successfully updated!", response });
        }

        [HttpPut("update-social-media-url")]
        public async Task<IActionResult> UpdateSocialMediaUrl(DoctorSocialMediaUrlLinkDTO model)
        {
            if (auth.Doctor == null) return Unauthorized();
            var urlLinkToBeUpdated = await urlLinkService.GetAsync(auth.Doctor.Id);
            await urlLinkService.UpdateAsync(urlLinkToBeUpdated, mapper.Map<DoctorSocialMediaUrlLink>(model));

            return Ok(new { message = "Social Media URLs successfully updated!" });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
        {
            if (auth.Doctor == null) return Unauthorized();
            var response = await userService.UpdateAsync(auth.Doctor.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            return Ok(new { message = "Password successfully updated!", response });
        }
        #endregion

        #region upload
        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (auth.Doctor == null) return Unauthorized();
            var image = await userService.PhotoUploadAsync(auth.Doctor.Id, file);
            return Ok(new { message = "Photo uploaded!", image });
        }
        #endregion
    }
}