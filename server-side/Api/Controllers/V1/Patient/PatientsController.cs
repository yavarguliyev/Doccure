using Api.Libs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1.Patient
{
    public class PatientsController : BaseApiController
    {
        private readonly IAuth _auth;

        public PatientsController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Patient == null) return Unauthorized();

            return Ok(_auth.Patient.Fullname);
        }
    }
}