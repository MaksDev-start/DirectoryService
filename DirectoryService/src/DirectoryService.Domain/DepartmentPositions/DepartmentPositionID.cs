using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain;

public sealed record DepartmentPositionID : EntityID
{
public DepartmentPositionID(Guid value) 
    : base(value)
{
}
    
public static DepartmentPositionID New() => new(Guid.NewGuid());
}