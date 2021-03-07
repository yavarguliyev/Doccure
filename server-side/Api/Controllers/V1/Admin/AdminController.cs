﻿using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class AdminController : BaseApiController
    {
        #region admin profile functionalities
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly IUserService _userService;

        public AdminController(IMapper mapper, 
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
            if (_auth.Admin == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(_auth.Admin);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserProfileUpdateDTO model)
        {
            if (_auth.Admin == null) return Unauthorized();

            var userToBeUpdated = await _userService.GetAsync(_auth.Admin.Id);
            var user = _mapper.Map<User>(model);
            var response = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user));

            return Ok(new
            {
                message = "Profile successfully updated!",
                response = response
            });
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] AuthPasswordUpdateDTO model)
        {
            if (_auth.Admin == null) return Unauthorized();
            var user = await _userService.UpdateAsync(_auth.Admin.Id, model.NewPassword, model.ConfirmPassword, model.CurrentPassword);
            var response = _mapper.Map<UserDTO>(user);

            return Ok(new
            {
                message = "Password successfully updated!",
                response = response
            });
        }

        [HttpPut("upload-photo")]
        public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
        {
            if (_auth.Admin == null) return Unauthorized();
            var response = _mapper.Map<UserDTO>(await _userService.PhotoUpload(_auth.Admin.Id, file));

            return Ok(new
            {
                message = "Photo uploaded!",
                response = response
            });
        }
        #endregion
    }
}