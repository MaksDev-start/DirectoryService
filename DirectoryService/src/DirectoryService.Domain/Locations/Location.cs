using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.Locations.ValueObjets;
using TimeZone = DirectoryService.Domain.Locations.ValueObjets.TimeZone;

namespace DirectoryService.Domain.Locations;

public sealed class Location
{
    private Location(
        LocationName name,
        TimeZone timeZone, 
        Adress adress)
    {
        Id = LocationID.New();
        Name = name;
        TimeZone = timeZone;
        Adress = adress;
        IsActiv = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    private List<DepartmentLocation> _departmentLocations = [];
    
    public LocationID Id { get; }

    public LocationName Name { get; private set; }
    
    public Adress Adress { get; private set; }
    
    public TimeZone TimeZone { get; private set; }
    
    public bool IsActiv { get; private set; } 
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    public static Result<Location> Create(
        string name,
        string timeZone,
        string country,
        string city,
        string street,
        int? streetNumber)
    {
        var nameResult = LocationName.Create(name);
        if (nameResult.IsFailure)
        {
            return Result.Failure<Location>(nameResult.Error);
        }
        
        var adressResult = Adress.Create(country, city, street, streetNumber);
        if (adressResult.IsFailure)
        {
            return Result.Failure<Location>(adressResult.Error);
        }
        
        var timeZoneResult = TimeZone.Create(timeZone);
        if (timeZoneResult.IsFailure)
        {
            return Result.Failure<Location>(timeZoneResult.Error);
        }
        
        return new Location(
            nameResult.Value,
            timeZoneResult.Value,
            adressResult.Value);
    }
    
}