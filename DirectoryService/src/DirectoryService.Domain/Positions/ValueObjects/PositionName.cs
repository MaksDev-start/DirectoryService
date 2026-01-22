using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionName
{
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
                name => name.Length <= LengthConstants.MAXLENGTH100,
                $"Position name cannot exceed {LengthConstants.MAXLENGTH100} characters.")
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                $"Position name must be at least {LengthConstants.MINLENGTH3} characters.")
            .Map(name => new PositionName(name));

    }
}