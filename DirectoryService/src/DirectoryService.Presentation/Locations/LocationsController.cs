using DirectoryService.Application.Abstractions;
using DirectoryService.Application.Locations.Features;
using DirectoryService.Contracts.Locations.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Locations;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICommandHandler<Guid, CreateLocationCommand> commandHandler,
        [FromBody] CreateLocationDto locationRequest,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(locationRequest);
        
        var result = await commandHandler.Handle(command, cancellationToken);

        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    } 
}