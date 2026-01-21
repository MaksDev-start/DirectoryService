using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record Description
{
    public const int MAX_LENGTH = 1000;
    
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
                desc => desc.Length <= MAX_LENGTH,
                $"Description cannot exceed {MAX_LENGTH} characters.")
            .Map(desc => new Description(desc));

    }
}