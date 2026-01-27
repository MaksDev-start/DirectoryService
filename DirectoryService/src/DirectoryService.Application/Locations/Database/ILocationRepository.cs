using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Application.Locations.Database;

public interface ILocationRepository
{
    Task<Result<Guid, string>> AddAsync(Location location, CancellationToken cancellationToken);
}