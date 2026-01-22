using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record Description
{
    
    private Description(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<Description> Create(string description)
    {
        return Result.Success(description)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                "Description cannot be empty")
            .Ensure(
                desc => desc.Length <= LengthConstants.MAXLENGTH1000,
                $"Description cannot exceed {LengthConstants.MAXLENGTH1000} characters.")
            .Map(desc => new Description(desc));

    }
}