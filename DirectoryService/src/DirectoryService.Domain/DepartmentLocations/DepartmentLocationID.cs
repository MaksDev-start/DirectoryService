using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.DepartmentLocations;

public sealed record DepartmentLocationID : EntityID
{
    private DepartmentLocationID(Guid value) 
        : base(value)
    {
    }
    
    public static DepartmentLocationID New(Guid? value = null) 
        => new(value ?? Guid.NewGuid());
}