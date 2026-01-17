using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.DepartmentLocations;

public sealed record DepartmentLocationID : EntityID
{
    public DepartmentLocationID(Guid value) 
        : base(value)
    {
    }
    
    public static DepartmentLocationID New() => new(Guid.NewGuid());
}