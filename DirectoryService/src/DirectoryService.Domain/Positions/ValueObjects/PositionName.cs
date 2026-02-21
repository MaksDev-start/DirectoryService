using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionName
{
    private PositionName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PositionName, Error> Create(string positionName)
    {
        return Result.Success<string, Error>(positionName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                GeneralErrors.ValueIsRequired(
                    "Position name cannot be empty"))
            .Ensure(
                name => name.Length <= LengthConstants.MAXLENGTH100,
                GeneralErrors.ValueIsInvalid(
                    $"Position name cannot exceed {LengthConstants.MAXLENGTH100} characters."))
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                GeneralErrors.ValueIsInvalid(
                    $"Position name must be at least {LengthConstants.MINLENGTH3} characters."))
            .Map(name => new PositionName(name));
    }
}