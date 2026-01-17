using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Departments.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    private List<DepartmentLocation> _locations = [];
    private List<DepartmentPosition> _positions = [];

    private Department(
        DepartmentName name,
        DepartmentIndefier indefier, 
        DepartmentPath path, 
        short depth,
        Department? parent = null)
    {
        Id = DepartmentID.New();
        Name = name;
        Indefier = indefier;
        Path = path;
        Depth = depth;
        IsActiv = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        Parent = parent;
    }
    
    public DepartmentID Id { get; }

    public DepartmentName Name { get; private set; }

    public DepartmentIndefier Indefier { get; private set; }

    public Department? Parent { get; private set; }
    
    public DepartmentPath Path { get; private set; }
    
    public short Depth { get; private set; }
    
    public bool IsActiv { get; private set; }
    
    public DateTime CreatedAt { get;  }
    
    public DateTime UpdatedAt { get; private set; }

    public static Result<Department> Create(
        string name,
        string indefier,
        string path,
        short depth,
        Department? parent = null)
    {
        var nameResult = DepartmentName.Create(name);
        if (nameResult.IsFailure)
        {
            return Result.Failure<Department>(nameResult.Error);
        }
        
        var indefierResult = DepartmentIndefier.Create(indefier);
        if (indefierResult.IsFailure)
        {
            return Result.Failure<Department>(indefierResult.Error);
        }
        
        var pathResult = DepartmentPath.Create(path);
        if (pathResult.IsFailure)
        {
            return Result.Failure<Department>(pathResult.Error);
        }
        
        return new Department(
            nameResult.Value,
            indefierResult.Value,
            pathResult.Value,
            depth, 
            parent);
    }
}