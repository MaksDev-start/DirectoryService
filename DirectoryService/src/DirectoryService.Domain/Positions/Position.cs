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

    public PositionName Name { get; }
    
    public Description Description { get; }
    
    public bool IsActiv { get; } 
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; }
    
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