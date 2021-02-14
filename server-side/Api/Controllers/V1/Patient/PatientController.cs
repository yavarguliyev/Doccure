using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Core.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1.Patient
{
    public class PatientController : BaseApiController
    {
        #region patient functionality
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

            return Ok(_mapper.Map<UserDTO>(_auth.Patient));
        }
        #endregion
    }
}