using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentPath
{
    private const string SEPARATOR = ".";

    private DepartmentPath(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<DepartmentPath> Create(string path, Department? parent = null)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Result.Failure<DepartmentPath>("Department path cannot be empty.");
        }

        if (path.Length > LengthConstants.MAXLENGTH100)
        {
            return Result.Failure<DepartmentPath>($"Department path cannot exceed {LengthConstants.MAXLENGTH100} characters.");
        }

        if (path.Length < LengthConstants.MINLENGTH3)
        {
            return Result.Failure<DepartmentPath>($"Department path must be at least {LengthConstants.MINLENGTH3} characters.");
        }

        if (parent is null)
        {
            return Result.Success(new DepartmentPath(path));
        }

        return Result.Success(new DepartmentPath($"{parent.Path.Value}{SEPARATOR}{path}"));
    }
}