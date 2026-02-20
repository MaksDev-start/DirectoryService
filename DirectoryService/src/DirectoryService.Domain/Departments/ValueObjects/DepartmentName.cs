using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentName
{
    private DepartmentName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentName, Error> Create(string departamentName)
    {
        return Result.Success<string, Error>(departamentName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                GeneralErrors.ValueIsRequired(
                    "Department name cannot be empty"))
            .Ensure(
                name => name.Length <= LengthConstants.MAXLENGTH150,
                GeneralErrors.ValueIsInvalid(
                    $"Department name cannot exceed {LengthConstants.MAXLENGTH150} characters."))
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                GeneralErrors.ValueIsInvalid(
                        $"Department name must be at least {LengthConstants.MINLENGTH3} characters."))
                    .Map(name => new DepartmentName(name));
    }
}