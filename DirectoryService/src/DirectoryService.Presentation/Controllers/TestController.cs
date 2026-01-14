using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        return await Task.FromResult("Test");
    }
}