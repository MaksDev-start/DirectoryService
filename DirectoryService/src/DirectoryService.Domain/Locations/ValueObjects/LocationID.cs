using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record LocationID : BaseId
{
    private LocationID(Guid value)
        : base(value)
    {
    }

    public static LocationID New(Guid? value = null) 
        => new(value ?? Guid.NewGuid());
}