using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record LocationName
{
    
    private LocationName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<LocationName, Error> Create(string locationName)
    {
        return Result.Success<string, Error>(locationName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                GeneralErrors.ValueIsRequired(
                    "Location name cannot be empty"))
            .Ensure(
                name => name.Length <= LengthConstants.MAXLENGTH120,
                GeneralErrors.ValueIsInvalid(
                    $"Location name cannot exceed {LengthConstants.MAXLENGTH120} characters."))
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                GeneralErrors.ValueIsInvalid(
                    $"Location name must be at least {LengthConstants.MINLENGTH3} characters."))
            .Map(name => new LocationName(name));

    }
}