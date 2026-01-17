namespace DirectoryService.Domain.Abstracts;

public abstract record EntityID
{
    protected EntityID(Guid value) => Value = value;
    public Guid Value { get; }

    public static implicit operator Guid(EntityID id) => id.Value;
    public static implicit operator string(EntityID id) => id.Value.ToString();
}