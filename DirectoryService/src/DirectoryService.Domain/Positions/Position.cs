using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions;

public sealed class Position
{
    private Position(
        PositionName name,
        Description description)
    {
        Id = PositionID.New();
        Name = name;
        Description = description;
        IsActiv = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    private List<DepartmentPosition> _departmentPositions = [];
    
    public PositionID Id { get; }

    public PositionName Name { get; private set; }
    
    public Description Description { get; private set; }
    
    public bool IsActiv { get; private set; } 
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    public static Result<Position> Create(
        string name,
        string description)
    {
        var nameResult = PositionName.Create(name);
        if (nameResult.IsFailure)
        {
            return Result.Failure<Position>(nameResult.Error);
        }
        
        var desc = Description.Create(description);
        if (desc.IsFailure)
        {
            return Result.Failure<Position>(desc.Error);
        }
        
        return new Position(
            nameResult.Value,
            desc.Value);
    }
}