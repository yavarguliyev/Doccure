using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Patient
{
    public class PatientController : BaseApiController
    {
        #region patient functionalities
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuth _auth;

        public PatientController(IMapper mapper, 
                                 IUserService userService, 
                                 IAuth auth)
        {
            _mapper = mapper;
            _userService = userService;
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_auth.Patient == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(_auth.Patient);

            return Ok(new
            {
                message = "Profile successfully updated!",
                response = response
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserProfileUpdateDTO model)
        {
            if (_auth.Patient == null) return Unauthorized();

            var userToBeUpdated = await _userService.GetAsync(_auth.Patient.Id);
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, _mapper.Map<User>(model)));

            return Ok(new
            {
                message = "Profile successfully updated!",
                response = response
            });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] AuthPasswordUpdateDTO model)
        {
            if (_auth.Patient == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(_auth.Patient.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword));

            return Ok(new
            {
                message = "Password successfully updated!",
                response = response
            });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
        {
            if (_auth.Patient == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.PhotoUpload(_auth.Patient.Id, file));

            return Ok(new 
            {
                message = "Photo uploaded!",
                response = response
            });
        }
        #endregion
    }
}