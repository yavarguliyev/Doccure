using Core.DTOs.Auth;
using Core.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await userService.GetAsync(UserRole.Doctor, null));

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug) => Ok(mapper.Map<UserDTO>(await userService.GetByAsync(slug)));
    }
}