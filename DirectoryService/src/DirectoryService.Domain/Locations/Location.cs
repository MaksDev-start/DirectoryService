using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.Locations.ValueObjects;
using TimeZone = DirectoryService.Domain.Locations.ValueObjects.TimeZone;

namespace DirectoryService.Domain.Locations;

public sealed class Location
{
    // EF core
    private Location()
    {
    }
    
    private Location(
        LocationName name,
        TimeZone timeZone, 
        Address address)
    {
        Id = LocationID.New();
        Name = name;
        TimeZone = timeZone;
        Address = address;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    private readonly List<DepartmentLocation> _departmentLocations = [];
    
    public LocationID Id { get; }

    public LocationName Name { get; private set; }
    
    public Address Address { get; private set; }
    
    public TimeZone TimeZone { get; private set; }
    
    public bool IsActive { get; private set; } 
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    public IReadOnlyList<DepartmentLocation> DepartmentLocation => _departmentLocations;
    
    public static Location Create(
        LocationName name,
        TimeZone timeZone,
        Address address)
    {
        return new Location(name, timeZone, address);
    }
    
}