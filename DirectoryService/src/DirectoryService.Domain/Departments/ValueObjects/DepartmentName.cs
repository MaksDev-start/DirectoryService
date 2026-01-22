using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentName
{
    
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
                name => name.Length <= LengthConstants.MAXLENGTH150,
                $"Department name cannot exceed {LengthConstants.MAXLENGTH150} characters.")
            .Ensure(
                name => name.Length >= LengthConstants.MINLENGTH3,
                $"Department name must be at least {LengthConstants.MINLENGTH3} characters.")
            .Map<string, DepartmentName>(name => new DepartmentName(name));

    }
}