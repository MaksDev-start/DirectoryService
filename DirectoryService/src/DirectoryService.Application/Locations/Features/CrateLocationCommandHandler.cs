using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions;
using DirectoryService.Application.Locations.Database;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Locations.ValueObjects;
using Microsoft.Extensions.Logging;
using TimeZone = DirectoryService.Domain.Locations.ValueObjects.TimeZone;

namespace DirectoryService.Application.Locations.Features;

public class CrateLocationCommandHandler(
    ILogger<CrateLocationCommandHandler> logger,
    ILocationRepository locationRepository)
    : ICommandHandler<Guid, CreateLocationCommand>
{
    private readonly ILogger<CrateLocationCommandHandler> _logger = logger;
    private readonly ILocationRepository _locationRepository = locationRepository;

    public async Task<Result<Guid, string>> Handle(
        CreateLocationCommand command,
        CancellationToken cancellationToken)
    {
        var locationNameResult = LocationName.Create(command.Name);
        if (locationNameResult.IsFailure)
            return Result.Failure<Guid, string>(locationNameResult.Error);

        var timeZoneResult = TimeZone.Create(command.TimeZone);
        if (timeZoneResult.IsFailure)
            return Result.Failure<Guid, string>(timeZoneResult.Error);

        var adressResult = Adress.Create(
            command.Adress.Country,
            command.Adress.City,
            command.Adress.Street,
            command.Adress.HouseNumber);
        if (adressResult.IsFailure)
            return Result.Failure<Guid, string>(adressResult.Error);

        var locatoin = Location.Create(
            locationNameResult.Value,
            timeZoneResult.Value,
            adressResult.Value);

        var result = await _locationRepository
            .AddAsync(locatoin, cancellationToken);

        if (result.IsFailure)
        {
            _logger.LogError("Failed to add location. Error: {Error}", result.Error);

            return result.Error;
        }

        _logger.LogInformation("Location created with id {locationId}", result.Value);

        return result.Value;
    }
}