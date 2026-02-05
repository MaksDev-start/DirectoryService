using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record LocationName
{
    
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
                name => name.Length <= LengthConstants.MAXLENGTH120,
                $"Location name cannot exceed {LengthConstants.MAXLENGTH120} characters.")
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                $"Location name must be at least {LengthConstants.MINLENGTH3} characters.")
            .Map(name => new LocationName(name));

    }
}