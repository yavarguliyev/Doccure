using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace Api.Controllers
{
    public class FallbackController : Controller
    {
        public ActionResult Index() => PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
    }
}