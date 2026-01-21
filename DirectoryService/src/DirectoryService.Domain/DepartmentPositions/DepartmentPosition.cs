using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.DepartmentPositions;

public sealed class DepartmentPosition
{
    // EF core
    private DepartmentPosition()
    {
    }
    
    public DepartmentPosition(
        DepartmentId departmentId,
        Department department,
        PositionId positionId,
        Position position,
        DepartmentPositionId id)
    {
        DepartmentId = departmentId;
        Department = department;
        PositionId = positionId;
        Position = position;
        Id = id;
    }
    
    public DepartmentPositionId Id { get; }

    public Department Department { get; private set; }

    public DepartmentId DepartmentId { get; } 

    public Position Position { get; private set; } 

    public PositionId PositionId { get; } 
}