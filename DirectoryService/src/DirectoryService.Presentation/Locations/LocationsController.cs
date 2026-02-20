using DirectoryService.Application.Abstractions;
using DirectoryService.Application.Locations.Features;
using DirectoryService.Contracts.Locations.DTOs;
using DirectoryService.Presentation.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Locations;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<EndpointResult<Guid>> Create(
        [FromServices] ICommandHandler<Guid, CreateLocationCommand> commandHandler,
        [FromBody] CreateLocationRequest locationRequest,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(
            locationRequest.Name,
            locationRequest.Adress,
            locationRequest.TimeZone);

        return await commandHandler.Handle(command, cancellationToken);
    }
}