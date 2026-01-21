using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionName
{
    public const int MAX_LENGTH = 100;
    private const int MIN_LENGTH = 3;
    
    private PositionName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<PositionName> Create(string positionName)
    {
        return Result.Success(positionName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                "Position name cannot be empty")
            .Ensure(
                name => name.Length <= MAX_LENGTH,
                $"Position name cannot exceed {MAX_LENGTH} characters.")
            .Ensure(
                name => name.Length >= MIN_LENGTH,
                $"Position name must be at least {MIN_LENGTH} characters.")
            .Map(name => new PositionName(name));

    }
}