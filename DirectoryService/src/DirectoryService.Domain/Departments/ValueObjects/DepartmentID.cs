using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentId : BaseId
{
    private DepartmentId(Guid value)
        : base(value)
    {
    }
    
    public static DepartmentId New(Guid? value = null) 
        => new(value ?? Guid.NewGuid());
}