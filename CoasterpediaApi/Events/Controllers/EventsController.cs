using Microsoft.AspNetCore.Mvc;

namespace CoasterpediaApi.Events.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{

    [HttpPost("/{*path}")]
    public async Task<IActionResult> Action(object request)
    {
        return Ok();
    }
}