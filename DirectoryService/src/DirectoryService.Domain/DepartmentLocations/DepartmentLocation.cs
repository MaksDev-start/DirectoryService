using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.DepartmentLocations;

public sealed class DepartmentLocation
{
    // EF core
    private DepartmentLocation()
    {
    }
    
    public DepartmentLocation(
        Department department, 
        Location location,
        DepartmentId departmentId,
        LocationID locationId, 
        DepartmentLocationID id)
    {
        Department = department;
        Location = location;
        DepartmentId = departmentId;
        LocationId = locationId;
        Id = id;
    }
    
    public DepartmentLocationID Id { get; }
    
    public Department Department { get; private set; }

    public DepartmentId DepartmentId { get; }
    
    public Location Location { get; private set; }
    
    public LocationID LocationId { get; }
        
}