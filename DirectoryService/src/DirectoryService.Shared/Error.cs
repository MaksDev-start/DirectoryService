namespace DirectoryService.Shared;

public record Error
{
    public string Message { get; }

    public string Code { get; }

    public ErrorType Type { get; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public static Error Validation(string code, string message)
        => new(code, message, ErrorType.VALIDATION);

    public static Error NotFound(string code, string message)
        => new(code, message, ErrorType.NOTFOUND);

    public static Error Conflict(string code, string message)
        => new(code, message, ErrorType.CONFLICT);

    public static Error Failure(string code, string message)
        => new(code, message, ErrorType.FAILURE);
}

public enum ErrorType
{
    VALIDATION,
    CONFLICT,
    NOTFOUND,
    FAILURE,
}