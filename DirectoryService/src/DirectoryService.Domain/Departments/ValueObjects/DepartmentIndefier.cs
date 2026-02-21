using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentIndefier
{
    
    private const string ONLY_LATIN = @"^[a-zA-Z\s\-]+$";

    private DepartmentIndefier(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<DepartmentIndefier, Error> Create(string departamentIdentifier)
    {
        return Result.Success<string, Error>(departamentIdentifier)
            .Ensure(
                identifier => !string.IsNullOrWhiteSpace(identifier),
                GeneralErrors.ValueIsRequired("Department identifier cannot be empty"))
            .Ensure(
                identifier => Regex.IsMatch(identifier, ONLY_LATIN),
                GeneralErrors.ValueIsInvalid(
                    "Department identifier must contain only Latin letters (a-z, A-Z)."))
            .Ensure(
                identifier => identifier.Length <= LengthConstants.MAXLENGTH150,
                GeneralErrors.ValueIsInvalid(
                    $"Department identifier cannot exceed {LengthConstants.MAXLENGTH150} characters."))
            .Ensure(
                identifier => identifier.Length >= LengthConstants.MINLENGTH3,
                GeneralErrors.ValueIsInvalid(
                    $"Department identifier must be at least {LengthConstants.MINLENGTH3} characters."))
            .Map(identifier => new DepartmentIndefier(identifier.Trim()));

    }

}