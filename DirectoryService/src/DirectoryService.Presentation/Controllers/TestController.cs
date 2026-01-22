using DirectoryService.Application;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestRepositiry _repoository;

    public TestController(ITestRepositiry repoository)
    {
        _repoository = repoository;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _repoository.GetAll();
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult> Add()
    { 
        await _repoository.Add();
        
        return Ok();
    }
}