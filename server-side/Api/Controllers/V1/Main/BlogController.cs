using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
  public class BlogController : BaseApiController
  {
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return Ok(await blogService.GetAsync());
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> Details(string slug)
    {
      return Ok(await blogService.GetAsync(slug));
    }
  }
}