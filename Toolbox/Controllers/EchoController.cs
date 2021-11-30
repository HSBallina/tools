using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Toolbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new OkObjectResult("Nothing here");
        }

        [HttpPost]
        public IActionResult Echo([FromBody] dynamic content)
        {
            return new OkObjectResult(JsonSerializer.Serialize(content));
        }
    }

    public class Pop
    {
        public string Yo { get; set; }
    }
}
