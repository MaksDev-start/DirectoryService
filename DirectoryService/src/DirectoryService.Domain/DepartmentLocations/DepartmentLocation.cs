using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations.ValueObjets;

namespace DirectoryService.Domain.DepartmentLocations;

public class DepartmentLocation
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
    
    public DepartmentID DepartmentId { get; }
    
    public LocationID LocationId { get; }
        
}