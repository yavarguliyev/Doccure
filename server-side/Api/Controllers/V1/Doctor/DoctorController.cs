using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Doctor
{
    public class DoctorController : BaseApiController
    {
        #region doctor functionalities
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly IUserService _userService;

        public DoctorController(IMapper mapper,
                                IAuth auth,
                                IUserService userService)
        {
            _mapper = mapper;
            _auth = auth;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_auth.Doctor == null) return Unauthorized();
            var response =_mapper.Map<UserDTO>(_auth.Doctor);

            return Ok(new
            {
                message = "You successfully completed the registration!",
                response = response
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] NewDoctorModifyDTO model, [FromQuery] string token)
        {
            var userToBeUpdated = await _userService.GetByConfirmTokenAsync(token);
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, _mapper.Map<User>(model)));

            return Ok(new
            {
                message = "You successfully completed the registration!",
                response = response
            });
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> Update([FromBody] UserProfileUpdateDTO model)
        {
            if (_auth.Doctor == null) return Unauthorized();
            var userToBeUpdated = await _userService.GetAsync(_auth.Doctor.Id);
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, _mapper.Map<User>(model)));

            return Ok(new
            {
                message = "You successfully completed the registration!",
                response = response
            });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] AuthPasswordUpdateDTO model)
        {
            if (_auth.Doctor == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(_auth.Doctor.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword));

            return Ok(new
            {
                message = "Password successfully updated!",
                response = response
            });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
        {
            if (_auth.Doctor == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.PhotoUpload(_auth.Doctor.Id, file));

            return Ok(new
            {
                message = "Photo uploaded!",
                response = response
            });
        }
        #endregion
    }
}