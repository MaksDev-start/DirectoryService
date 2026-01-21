using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentIndefier
{
    public const int MAX_LENGTH = 150;
    private const int MIN_LENGTH = 3;
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
                indefier => indefier.Length <= MAX_LENGTH,
                $"Department identifier cannot exceed {MAX_LENGTH} characters.")
            .Ensure(
                indefier => indefier.Length >= MIN_LENGTH,
                $"Department identifier must be at least {MIN_LENGTH} characters.")
            .Map(indefier => new DepartmentIndefier(indefier));

    }

}