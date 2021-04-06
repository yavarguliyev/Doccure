using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
  public class BlogController : BaseApiController
  {
    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
      return Ok(await blogService.GetAsync());
    }

    [HttpGet("details/{slug}")]
    public async Task<IActionResult> Details(string slug)
    {
      return Ok(await blogService.GetAsync(slug));
    }
  }
}