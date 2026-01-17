using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations.ValueObjets;

namespace DirectoryService.Domain.DepartmentLocations;

public sealed class DepartmentLocation
{
    public DepartmentLocation(
        DepartmentID departmentId, 
        LocationID locationId)
    {
        Id = DepartmentLocationID.New();
        DepartmentId = departmentId;
        LocationId = locationId;

    }
    
    public DepartmentLocationID Id { get; }
    
    public DepartmentID DepartmentId { get; private set; }
    
    public LocationID LocationId { get; private set; }
        
}