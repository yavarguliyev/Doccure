using Api.Libs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1.Doctor
{
    public class DoctorsController : BaseApiController
    {
        private readonly IAuth _auth;

        public DoctorsController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Doctor == null) return Unauthorized();

            return Ok(_auth.Doctor.Fullname);
        }
    }
}