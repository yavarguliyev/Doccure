using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Doctor
{
    public class DoctorController : BaseApiController
    {
        #region doctor functionality
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuth _auth;

        public DoctorController(IMapper mapper,
                                 IUserService userService,
                                 IAuth auth)
        {
            _mapper = mapper;
            _userService = userService;
            _auth = auth;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AdminNewDoctorModifyDTO model, [FromQuery] string token)
        {
            var userToBeUpdated = await _userService.GetByInviteTokenAsync(token);
            var user = _mapper.Map<User>(model);

            return Ok(new 
            {
                message = "You successfully completed the registration",
                user = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user))
            });
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
        #endregion
    }
}