using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionID : EntityID
{
    private PositionID(Guid value) 
        : base(value)
    {
    }
    
    public static PositionID New() => new(Guid.NewGuid());
}