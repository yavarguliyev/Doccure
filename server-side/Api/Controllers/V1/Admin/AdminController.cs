using Api.Libs;
using AutoMapper;
using Core.DTOs.Admin.Admin_Profile;
using Core.DTOs.Auth;
using Core.Models;
using Core.Services.Data;
using CryptoHelper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class AdminController : BaseApiController
    {
        #region admin profile functionality
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

            return Ok(_mapper.Map<UserDTO>(_auth.Admin));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdminProfileUpdateDTO model)
        {
            if (_auth.Admin == null) return Unauthorized();

            var userToBeUpdated = await _userService.GetAsync(_auth.Admin.Id);
            var user = _mapper.Map<User>(model);

            if (model.Password != null || model.ConfirmPassword != null)
            {
                if (Crypto.VerifyHashedPassword(userToBeUpdated.Password, model.Password))
                {
                    ModelState.AddModelError("Password", "Current password cannot match old password");
                    return BadRequest(ModelState);
                }
                else if (model.ConfirmPassword != model.Password)
                {
                    ModelState.AddModelError("Confirm Password", "Confirm Password should match current password");
                    return BadRequest(ModelState);
                }
            }

            return Ok(new
            {
                message = "Profile successfully updated",
                user = _mapper.Map<UserDTO>(await _userService.UpdateAsync(userToBeUpdated, user))
            });
        }
        #endregion
    }
}