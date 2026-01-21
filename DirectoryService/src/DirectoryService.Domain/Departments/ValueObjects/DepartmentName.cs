using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentName
{
    public const int MAX_LENGTH = 150;
    public const int MIN_LENGTH = 3;
    private DepartmentName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static Result<DepartmentName> Create(string departamentName)
    {
        return Result.Success(departamentName)
            .Ensure(
                name => !string.IsNullOrWhiteSpace(name),
                "Department name cannot be empty")
            .Ensure(
                name => name.Length <= MAX_LENGTH,
                $"Department name cannot exceed {MAX_LENGTH} characters.")
            .Ensure(
                name => name.Length >= MIN_LENGTH,
                $"Department name must be at least {MIN_LENGTH} characters.")
            .Map<string, DepartmentName>(name => new DepartmentName(name));

    }
}