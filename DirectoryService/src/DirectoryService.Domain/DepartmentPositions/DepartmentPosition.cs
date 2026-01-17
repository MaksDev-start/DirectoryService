using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.DepartmentPositions;

public class DepartmentPosition
{
    public DepartmentPosition(
        DepartmentID departmentId, 
        PositionID positionID)
    {
        Id = DepartmentPositionID.New();
        DepartmentId = departmentId;
        PositionID = positionID;

    }
    
    public DepartmentPositionID Id { get; }
    
    public DepartmentID DepartmentId { get; }
    
    public PositionID PositionID { get; }
}