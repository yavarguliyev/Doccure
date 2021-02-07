using Api.Libs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1.Admin
{
    public class AdminsController : BaseApiController
    {
        private readonly IAuth _auth;

        public AdminsController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (_auth.Admin == null) return Unauthorized();

            return Ok(_auth.Admin.Fullname);
        }
    }
}