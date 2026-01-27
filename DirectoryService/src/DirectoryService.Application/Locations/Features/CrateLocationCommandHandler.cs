using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions;
using DirectoryService.Application.Locations.Database;
using DirectoryService.Domain.Locations;
using Microsoft.Extensions.Logging;

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
        var locatoin = Location.Create(
            command.LocationDto.Name,
            command.LocationDto.TimeZone,
            command.LocationDto.Adress.Country,
            command.LocationDto.Adress.City,
            command.LocationDto.Adress.Street,
            command.LocationDto.Adress.HouseNumber);

        if (locatoin.IsFailure)
        {
            _logger.LogError("Failed to create location. Error: {Error}", locatoin.Error);
            
            return Result.Failure<Location>(locatoin.Error).ToString();
        }

        var result = await _locationRepository.AddAsync(locatoin.Value, cancellationToken);

        if (result.IsFailure)
        {
            _logger.LogError("Failed to add location. Error: {Error}", result.Error);
            
            return result.Error;
        }
        
        _logger.LogInformation("Location created with id {locationId}", locatoin.Value.Id.Value);
        
        return result.Value;
    }

}