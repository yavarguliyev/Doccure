using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
    public class ChatController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetChat(int id)
        {
            return Ok(await chatService.GetAsync(id));
        }
    }
}