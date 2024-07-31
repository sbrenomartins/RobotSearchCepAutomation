using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("v1")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Working");
    }
}
