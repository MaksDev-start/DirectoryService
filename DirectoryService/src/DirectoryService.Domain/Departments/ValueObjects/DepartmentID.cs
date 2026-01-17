using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentID : EntityID
{
    private DepartmentID(Guid value)
        : base(value)
    {
    }
    
    public static DepartmentID New() => new DepartmentID(Guid.NewGuid());
}