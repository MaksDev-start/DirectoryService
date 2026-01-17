using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.ValueObjets;

public sealed record LocationName
{
    private const int MAX_LENGTH = 120;
    private const int MIN_LENGTH = 3;
    
    private LocationName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<LocationName> Create(string locationName)
    {
        return Result.Success(locationName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                "Location name cannot be empty")
            .Ensure(
                name => name.Length <= MAX_LENGTH,
                $"Location name cannot exceed {MAX_LENGTH} characters.")
            .Ensure(
                name => name.Length >= MIN_LENGTH,
                $"Location name must be at least {MIN_LENGTH} characters.")
            .Map(name => new LocationName(name));

    }
}