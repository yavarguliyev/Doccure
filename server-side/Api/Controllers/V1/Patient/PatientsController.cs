using Api.Libs;
using AutoMapper;
using Core.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1.Patient
{
    public class PatientsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAuth _auth;

        public PatientsController(IMapper mapper, IAuth auth)
        {
            _mapper = mapper;
            _auth = auth;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Patient == null) return Unauthorized();

            return Ok(_mapper.Map<UserDTO>(_auth.Patient));
        }
    }
}