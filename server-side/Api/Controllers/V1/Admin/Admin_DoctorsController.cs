using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class Admin_DoctorsController : BaseApiController
    {
        #region admin_doctor crud
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly IUserService _userService;

        public Admin_DoctorsController(IMapper mapper,
                                       IAuth auth,
                                       IUserService userService)
        {
            _mapper = mapper;
            _auth = auth;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_auth.Admin == null) return Unauthorized();
            var response = _mapper.Map<IEnumerable<UserDTO>>(await _userService.GetAsync(UserRole.Doctor));

            return Ok(new
            {
                message = "",
                response = response
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (_auth.Admin == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.GetAsync(id));

            return Ok(new
            {
                message = "",
                response = response
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminCreateDoctorDTO model)
        {
            if (_auth.Admin == null) return Unauthorized();

            await _userService.CreateAsync(_mapper.Map<User>(model), UserRole.Doctor);

            return Ok(new
            {
                message = "New doctor registered!"
            });
        }

        [HttpPut("status")]
        public async Task<IActionResult> Status([FromQuery] int id)
        {
            if (_auth.Admin == null) return Unauthorized();
            await _userService.StatusAsync(id);

            return Ok(new
            {
                message = "Status modified"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (_auth.Admin == null) return Unauthorized();
            var user = await _userService.GetAsync(id);
            await _userService.DeleteAsync(user);

            return Ok(new
            {
                message = "Selected doctor removed from database"
            });
        }
        #endregion
    }
}