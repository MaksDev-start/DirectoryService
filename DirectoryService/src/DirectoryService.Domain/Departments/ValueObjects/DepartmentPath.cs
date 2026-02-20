using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentPath
{
    private const string SEPARATOR = ".";

    private DepartmentPath(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<DepartmentPath, Error> Create(string path, Department? parent = null)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            GeneralErrors.ValueIsRequired("Department path cannot be empty.");
        }

        if (path.Length > LengthConstants.MAXLENGTH100)
        {
            return GeneralErrors.ValueIsInvalid($"Department path cannot exceed {LengthConstants.MAXLENGTH100} characters.");
        }

        if (path.Length < LengthConstants.MINLENGTH3)
        {
            return GeneralErrors.ValueIsInvalid($"Department path must be at least {LengthConstants.MINLENGTH3} characters.");
        }

        if (parent is null)
        {
            return new DepartmentPath(path);
        }

        return new DepartmentPath($"{parent.Path.Value}{SEPARATOR}{path}");
    }
}