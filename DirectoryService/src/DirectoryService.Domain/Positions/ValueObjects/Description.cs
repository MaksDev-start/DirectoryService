using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record Description
{
    
    private Description(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<Description, Error> Create(string description)
    {
        return Result.Success<string, Error>(description)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                GeneralErrors.ValueIsRequired(
                    "Description cannot be empty"))
            .Ensure(
                desc => desc.Length <= LengthConstants.MAXLENGTH1000,
                GeneralErrors.ValueIsInvalid(
                    $"Description cannot exceed {LengthConstants.MAXLENGTH1000} characters."))
            .Map(desc => new Description(desc));

    }
}