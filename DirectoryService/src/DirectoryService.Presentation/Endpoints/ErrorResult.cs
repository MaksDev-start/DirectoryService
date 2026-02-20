using DirectoryService.Shared;

namespace DirectoryService.Presentation.Endpoints;

public class ErrorResult : IResult
{
    private readonly Error _error;

    public ErrorResult(Error error)
    {
        _error = error;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        int statusCode = GetStatusCodeFromeErrorType(_error.Type);

        var envelope = Envelope.Fail(_error);

        httpContext.Response.StatusCode = statusCode;
        
        return httpContext.Response.WriteAsJsonAsync(envelope);
    }

    private static int GetStatusCodeFromeErrorType(ErrorType errorType)
        => errorType switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            ErrorType.NOTFOUND => StatusCodes.Status404NotFound,
            ErrorType.FAILURE => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
}