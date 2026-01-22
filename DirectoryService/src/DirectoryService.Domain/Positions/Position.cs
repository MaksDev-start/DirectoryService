using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions;

public sealed class Position
{
    
    // EF core
    private Position()
    {
    }
    
    private Position(
        PositionName name,
        Description? description = null)
    {
        Id = PositionId.New();
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        Description = description;
    }
    
    private readonly List<DepartmentPosition> _departmentPositions = [];
    
    public PositionId Id { get; }

    public PositionName Name { get; private set; }
    
    public Description? Description { get; private set; }
    
    public bool IsActive { get; private set; } 
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
    
    public static Result<Position> Create(
        string name,
        string? description)
    {
        var nameResult = PositionName.Create(name);
        if (nameResult.IsFailure)
        {
            return Result.Failure<Position>(nameResult.Error);
        }
        
        Description? descValue = null;
    
        if (!string.IsNullOrWhiteSpace(description))
        {
            var descResult = Description.Create(description);
            if (descResult.IsFailure)
            {
                return Result.Failure<Position>(descResult.Error);
            }

            descValue = descResult.Value;
        }
        
        return new Position(
            nameResult.Value,
            descValue);
    }
}