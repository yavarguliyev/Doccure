using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1.Main
{
    public class CommentController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get(string slug)
        {
            return Ok(await commentService.GetAsync(slug));
        }
    }
}