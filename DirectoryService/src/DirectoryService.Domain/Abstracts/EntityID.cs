namespace DirectoryService.Domain.Abstracts;

public abstract record BaseId
{
    protected BaseId(Guid value) => Value = value;
    public Guid Value { get; }

    public static implicit operator Guid(BaseId id) => id.Value;
    public static implicit operator string(BaseId id) => id.Value.ToString();
}