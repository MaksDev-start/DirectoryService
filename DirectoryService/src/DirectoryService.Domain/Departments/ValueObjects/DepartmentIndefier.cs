using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentIndefier
{
    
    private const string ONLY_LATIN = @"^[a-zA-Z\s\-]+$";

    private DepartmentIndefier(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<DepartmentIndefier> Create(string departamentIndefier)
    {
        return Result.Success(departamentIndefier)
            .Ensure(
                indefier => !string.IsNullOrWhiteSpace(indefier),
                "Department identifier cannot be empty")
            .Ensure(
                indefier => Regex.IsMatch(indefier, ONLY_LATIN),
                "Department identifier must contain only Latin letters (a-z, A-Z).")
            .Ensure(
                indefier => indefier.Length <= LengthConstants.MAXLENGTH150,
                $"Department identifier cannot exceed {LengthConstants.MAXLENGTH150} characters.")
            .Ensure(
                indefier => indefier.Length >= LengthConstants.MINLENGTH3,
                $"Department identifier must be at least {LengthConstants.MINLENGTH3} characters.")
            .Map(indefier => new DepartmentIndefier(indefier));

    }

}