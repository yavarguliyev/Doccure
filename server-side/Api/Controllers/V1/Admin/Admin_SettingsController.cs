using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
  public class Admin_SettingsController : BaseApiController
  {
    #region admin_settings read
    [HttpGet("settings")]
    public async Task<IActionResult> Setting() => Ok(await SettingService.GetAsync());

    [HttpGet("setting-photo")]
    public async Task<IActionResult> SettingPhoto(string name) => Ok(await SettingPhotoService.GetAsync(name));

    [HttpGet("social-media")]
    public async Task<IActionResult> SocialMedia() => Ok(await SocialMediaService.GetAsync());

    [HttpGet("privacies")]
    public async Task<IActionResult> Privacies() => Ok(await PrivacyService.GetAsync());

    [HttpGet("terms")]
    public async Task<IActionResult> Terms() => Ok(await TermService.GetAsync());

    [HttpGet("features")]
    public async Task<IActionResult> Features() => Ok(await FeatureService.GetAsync());

    [HttpGet("specialities")]
    public async Task<IActionResult> Specialities() => Ok(await SpecialityService.GetAsync());

    [HttpGet("setting-photos")]
    public async Task<IActionResult> SettingPhotos() => Ok(await SettingPhotoService.GetAsync());
    #endregion

    #region admin_settings edit
    [HttpPut("settings")]
    public IActionResult EditSettings()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok();
    }

    [HttpPut("setting-photo")]
    public IActionResult UploadSettingPhoto()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok();
    }

    [HttpPut("social-media")]
    public IActionResult EditSocialMedia()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok();
    }

    [HttpPut("privacies")]
    public IActionResult EditPrivacies()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok();
    }

    [HttpPut("terms")]
    public IActionResult EditTerms()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok();
    }
    #endregion
  }
}