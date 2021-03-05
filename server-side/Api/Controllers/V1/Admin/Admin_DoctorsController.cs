using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System;
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

            return Ok(_mapper.Map<IEnumerable<UserDTO>>(await _userService.GetAsync(UserRole.Doctor)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (_auth.Admin == null) return Unauthorized();

            return Ok(_mapper.Map<UserDTO>(await _userService.GetAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminCreateDoctorDTO model)
        {
            if (_auth.Admin == null) return Unauthorized();

            var user = _mapper.Map<User>(model);
            user.ConfirmToken = Guid.NewGuid().ToString();
            await _userService.CreateAsync(user, UserRole.Doctor);

            return Ok(new { message = "Check your email to complete register process" });
        }

        [HttpPut("status")]
        public async Task<IActionResult> Status([FromQuery] int id)
        {
            if (_auth.Admin == null) return Unauthorized();

            await _userService.StatusAsync(id);

            return Ok(new { message = "Status modified" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (_auth.Admin == null) return Unauthorized();

            var user = await _userService.GetAsync(id);
            await _userService.DeleteAsync(user);

            return Ok(new { message = "Selected doctor removed from database" });
        }
        #endregion
    }
}