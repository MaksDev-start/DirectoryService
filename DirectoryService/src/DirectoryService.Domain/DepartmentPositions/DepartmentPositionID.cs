using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.DepartmentPositions;

public sealed record DepartmentPositionId : EntityID
{
    private DepartmentPositionId(Guid value) 
    : base(value)
{
}
    
public static DepartmentPositionId New(Guid? value = null) 
    => new(value ?? Guid.NewGuid());
}