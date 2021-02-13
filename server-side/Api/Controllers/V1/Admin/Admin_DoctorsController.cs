using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Core.Services.Common;
using Core.Services.Data;
using Data.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers.V1.Admin
{
    [Route("api/v1/admin/doctors")]
    [ApiController]
    public class Admin_DoctorsController : BaseApiController
    {
        #region admin_doctor crud
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly IUserService _userService;
        private readonly IActivityService _activityService;

        public Admin_DoctorsController(IMapper mapper,
                                IAuth auth,
                                IUserService userService,
                                IActivityService activityService)
        {
            _mapper = mapper;
            _auth = auth;
            _userService = userService;
            _activityService = activityService;
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
            user.InviteToken = Guid.NewGuid().ToString();
            var mapped = _mapper.Map<UserDTO>(await _userService.CreateAsync(user, UserRole.Doctor));
            var createdUser = await _userService.GetByInviteTokenAsync(mapped.InviteToken);

            var url = string.Empty;

            switch (createdUser.Role)
            {
                case UserRole.Doctor:
                    url = $"/doctors/register/{createdUser.InviteToken}";
                    break;
                default:
                    throw new RestException(HttpStatusCode.BadRequest, new { user = "Make sure you have valid role for creating your profile." });
            }

            await _activityService.SendEmail(createdUser,
                "Complete register process",
                "Register account",
                "To complete register process please fill out all the neessary inputs!",
                true,
                "Complete register process",
                url);

            return Ok("Check your email to complete register process");
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