namespace DirectoryService.Shared;

public static class GeneralErrors
{
    public static Error ValueIsInvalid(string? massage = null)
    {
        return Error.Validation("value.is.invalid", massage ?? "Value is invalid");
    }

    public static Error NotFound(Guid? id = null)
    {
        string withId = id == null ? string.Empty : $"with id:{id}";
        return Error.NotFound("record.not.found", $"Record {withId}  not found");
    }

    public static Error ValueIsRequired(string? massage = null)
    {
        return Error.Validation("value.is.required", massage ?? "Value is required");
    }

    public static Error AlreadyExist(string? name = null)
    {
        string label = name ?? "Record";
        return Error.Conflict("record.already.exist", $"{label} is already exist");
    }

    public static Error Failure(string? massage = null)
    {
        return Error.Failure("server.failure", massage ?? "Internal error");
    }
}