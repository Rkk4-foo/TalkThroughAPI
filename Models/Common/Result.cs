namespace TalkThroughAPI.Models.Common
{
    public record Result<T>(
        bool Success,
        string Message,
        T? Data,
        int StatusCode = StatusCodes.Status200OK,
        string? ErrorCode = null
        );
}
