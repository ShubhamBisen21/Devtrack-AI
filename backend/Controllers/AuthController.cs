using DevTrackAI.Api.DTOs;
using DevTrackAI.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(JwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
    {
        await Task.CompletedTask;

        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Username and password are required.");
        }

        var token = _jwtTokenGenerator.GenerateToken(request.Username);
        return Ok(new LoginResponse { Token = token });
    }
}
