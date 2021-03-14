using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class Admin_SettingsController : BaseApiController
    {
        #region admin_settings read
        [HttpGet("settings")]
        public async Task<IActionResult> Setting()
        {
            return Ok(await settingService.GetAsync());
        }

        [HttpGet("setting-photo")]
        public async Task<IActionResult> SettingPhoto(string name)
        {
            return Ok(await settingPhotoService.GetAsync(name));
        }

        [HttpGet("social-media")]
        public async Task<IActionResult> SocialMedia()
        {
            return Ok(await socialMediaService.GetAsync());
        }

        [HttpGet("privacies")]
        public async Task<IActionResult> Privacies()
        {
            return Ok(await privacyService.GetAsync());
        }

        [HttpGet("terms")]
        public async Task<IActionResult> Terms()
        {
            return Ok(await termService.GetAsync());
        }

        [HttpGet("setting-photos")]
        public async Task<IActionResult> SettingPhotos()
        {
            if (auth.Admin == null) return Unauthorized();
            return Ok(await settingPhotoService.GetAsync());
        }
        #endregion

        #region admin_settings edit
        [HttpPut("settings")]
        public IActionResult EditSettings()
        {
            if (auth.Admin == null) return Unauthorized();

            return Ok();
        }

        [HttpPut("setting-photo")]
        public IActionResult UploadSettingPhoto()
        {
            if (auth.Admin == null) return Unauthorized();

            return Ok();
        }

        [HttpPut("social-media")]
        public IActionResult EditSocialMedia()
        {
            if (auth.Admin == null) return Unauthorized();

            return Ok();
        }

        [HttpPut("privacies")]
        public IActionResult EditPrivacies()
        {
            if (auth.Admin == null) return Unauthorized();

            return Ok();
        }
        
        [HttpPut("terms")]
        public IActionResult EditTerms()
        {
            if (auth.Admin == null) return Unauthorized();

            return Ok();
        }
        #endregion
    }
}