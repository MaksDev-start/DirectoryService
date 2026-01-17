using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.DepartmentPositions;

public sealed class DepartmentPosition
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
    
    public DepartmentID DepartmentId { get; private set; }
    
    public PositionID PositionID { get; private set; }
}