using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Departments.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    // EF core
    private Department()
    {
    }

    private readonly List<DepartmentLocation> _locations = [];
    private readonly List<DepartmentPosition> _positions = [];

    private Department(
        DepartmentName name,
        DepartmentIndefier indefier,
        DepartmentPath path,
        short? depth = null,
        DepartmentId? parent = null)
    {
        Id = DepartmentId.New();
        Name = name;
        Indefier = indefier;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        ParentId = parent;
    }

    public DepartmentId Id { get; }

    public DepartmentName Name { get; private set; }

    public DepartmentIndefier Indefier { get; private set; }

    public DepartmentId? ParentId { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short? Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> DepartmentLocation => _locations;

    public IReadOnlyList<DepartmentPosition> DepartmentPosition => _positions;

    public static Result<Department> Create(
        DepartmentName departmentName,
        DepartmentIndefier departmentIndefier,
        DepartmentPath departmentPath,
        short depth,
        DepartmentId? parent = null)
    {
        return new Department(
            departmentName,
            departmentIndefier,
            departmentPath,
            depth,
            parent);
    }
}