using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
    public class AdminsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly IUserService _userService;

        public AdminsController(IMapper mapper, 
                                IAuth auth, 
                                IUserService userService)
        {
            _mapper = mapper;
            _auth = auth;
            _userService = userService;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Admin == null) return Unauthorized();

            return Ok(_mapper.Map<UserDTO>(_auth.Admin));
        }

        [HttpGet("users")]
        public async Task<IActionResult> Users([FromQuery] UserRole role)
        {
            if (_auth.Admin == null) return Unauthorized();

            return Ok(_mapper.Map<IEnumerable<UserDTO>>(await _userService.GetAsync(role)));
        }
    }
}