using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionId : BaseId
{
    private PositionId(Guid value) 
        : base(value)
    {
    }
    
    public static PositionId New(Guid? value = null) 
        => new(value ?? Guid.NewGuid());
}