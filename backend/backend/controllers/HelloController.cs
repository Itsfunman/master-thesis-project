using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api")]
public class HelloController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult Hello([FromQuery] string? name)
        => Ok(new { message = $"Hello {(string.IsNullOrWhiteSpace(name) ? "from ASP.NET" : name)}!" });
}
