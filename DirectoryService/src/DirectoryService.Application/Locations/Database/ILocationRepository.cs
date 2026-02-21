using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations;
using DirectoryService.Shared;

namespace DirectoryService.Application.Locations.Database;

public interface ILocationRepository
{
    Task<Result<Guid, Error>> AddAsync(Location location, CancellationToken cancellationToken);
}