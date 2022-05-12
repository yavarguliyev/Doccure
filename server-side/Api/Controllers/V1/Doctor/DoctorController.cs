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
      if (Auth.Doctor == null) return Unauthorized();
      return Ok(Mapper.Map<IEnumerable<UserDTO>>(await UserService.GetAsync(UserRole.Patient, null)));
    }

    [HttpGet("patient/{slug}")]
    public async Task<IActionResult> GetPatientBySlug(string slug)
    {
      if (Auth.Doctor == null) return Unauthorized();
      return Ok(Mapper.Map<UserDTO>(await UserService.GetByAsync(slug)));
    }
    #endregion

    #region doctor
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      if (Auth.Doctor == null) return Unauthorized();
      return Ok(Mapper.Map<UserDTO>(await UserService.GetAsync(Auth.Doctor.Id)));
    }

    [HttpGet("social-media-url")]
    public async Task<IActionResult> GetDoctorSocialMedialUrl()
    {
      if (Auth.Doctor == null) return Unauthorized();
      return Ok(Mapper.Map<DoctorSocialMediaUrlLinkDTO>(await UrlLinkService.GetAsync(Auth.Doctor.Id)));
    }
    #endregion

    #region update
    [HttpPut]
    public async Task<IActionResult> Register(NewDoctorModifyDTO model, string token)
    {
      var userToBeUpdated = await UserService.GetAsync(token);
      var response = await UserService.UpdateAsync(userToBeUpdated, Mapper.Map<User>(model));
      return Ok(new { message = "Registration successfully completed!", response });
    }

    [HttpPut("update-profile")]
    public async Task<IActionResult> Update(UserProfileUpdateDTO model)
    {
      if (Auth.Doctor == null) return Unauthorized();
      var userToBeUpdated = await UserService.GetAsync(Auth.Doctor.Id);
      var response = await UserService.UpdateAsync(userToBeUpdated, Mapper.Map<User>(model));

      return Ok(new { message = "Profile info successfully updated!", response });
    }

    [HttpPut("update-social-media-url")]
    public async Task<IActionResult> UpdateSocialMediaUrl(DoctorSocialMediaUrlLinkDTO model)
    {
      if (Auth.Doctor == null) return Unauthorized();
      var urlLinkToBeUpdated = await UrlLinkService.GetAsync(Auth.Doctor.Id);
      await UrlLinkService.UpdateAsync(urlLinkToBeUpdated, Mapper.Map<DoctorSocialMediaUrlLink>(model));

      return Ok(new { message = "Social Media URLs successfully updated!" });
    }

    [HttpPut("update-password")]
    public async Task<IActionResult> UpdatePassword(AuthPasswordUpdateDTO model)
    {
      if (Auth.Doctor == null) return Unauthorized();
      var response = await UserService.UpdateAsync(Auth.Doctor.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
      return Ok(new { message = "Password successfully updated!", response });
    }
    #endregion

    #region upload
    [HttpPut("upload-photo")]
    public async Task<IActionResult> UploadPhoto(IFormFile file)
    {
      if (Auth.Doctor == null) return Unauthorized();
      var image = await UserService.PhotoUploadAsync(Auth.Doctor.Id, file);
      return Ok(new { message = "Photo uploaded!", image });
    }
    #endregion
  }
}