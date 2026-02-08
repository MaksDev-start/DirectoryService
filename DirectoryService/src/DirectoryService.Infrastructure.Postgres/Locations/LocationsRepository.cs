using CSharpFunctionalExtensions;
using DirectoryService.Application.Locations.Database;
using DirectoryService.Domain.Locations;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure.Postgres.Locations;

public class LocationsRepository(
    DirectoryServiceDbContext dbContext,
    ILogger<LocationsRepository> logger) : ILocationRepository
{
    private ILogger<LocationsRepository> _logger = logger;
    private readonly DirectoryServiceDbContext _dbContext = dbContext;

    public async Task<Result<Guid, string>> AddAsync(
        Location location,
        CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return location.Id.Value;
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to add location. Error: {Error}", e.Message);
            return e.Message;
        }
    }
}