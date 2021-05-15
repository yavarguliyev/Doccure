using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
    public class ReviewController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await reviewService.GetAsync(id));
        }
    }
}