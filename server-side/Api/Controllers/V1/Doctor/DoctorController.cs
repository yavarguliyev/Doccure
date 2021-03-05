using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Doctor
{
    public class DoctorController : BaseApiController
    {
        #region doctor functionality
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

            return Ok(new 
            {
                doctor = _mapper.Map<UserDTO>(_auth.Doctor)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AdminNewDoctorModifyDTO model, [FromQuery] string token)
        {
            var userToBeUpdated = await _userService.GetByConfirmTokenAsync(token);
            var user = _mapper.Map<User>(model);
            user.ConfirmToken = null;

            return Ok(new
            {
                message = "You successfully completed the registration",
                user = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user))
            });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
        {
            if (_auth.Doctor == null) return Unauthorized();

            return Ok(new
            {
                message = "Photo uploaded!",
                response = _mapper.Map<UserDTO>(await _userService.PhotoUpload(_auth.Doctor.Id, file))
            });
        }
        #endregion
    }
}