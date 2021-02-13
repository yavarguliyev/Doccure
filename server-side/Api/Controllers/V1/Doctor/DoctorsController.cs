using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1.Doctor
{
    public class DoctorsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAuth _auth;

        public DoctorsController(IMapper mapper, 
                                 IAuth auth)
        {
            _mapper = mapper;
            _auth = auth;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Doctor == null) return Unauthorized();

            return Ok(_mapper.Map<UserDTO>(_auth.Doctor));
        }
    }
}