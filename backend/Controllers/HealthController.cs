using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        await Task.CompletedTask;
        return Ok(new { status = "ok", timestampUtc = DateTime.UtcNow });
    }
}
