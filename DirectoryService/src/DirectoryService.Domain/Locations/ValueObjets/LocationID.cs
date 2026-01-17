using DirectoryService.Domain.Abstracts;

namespace DirectoryService.Domain.Locations.ValueObjets;

public sealed record LocationID : EntityID
{
    private LocationID(Guid value)
        : base(value)
    {
    }

    public static LocationID New() => new(Guid.NewGuid());
}