using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
  public class ChatController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file) => Ok(await ChatMessageService.Upload(file));
  }
}
