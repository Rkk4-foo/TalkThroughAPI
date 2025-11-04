namespace TalkThroughAPI.Models.Common
{
    public record Result<T>(
        bool Success,
        string Message,
        T? Data,
        int StatusCode = StatusCodes.Status200OK,
        string? ErrorCode = null
        )
    {
        public static Result<T> SuccessR(
                T data,
                string message,
                int statusCode = StatusCodes.Status200OK)
            => new (true,message,data,statusCode);

        public static Result<T> Failure(
                string message,
                int statusCode = StatusCodes.Status400BadRequest,
                string errorCode = null)
            => new(false, message, default, statusCode, errorCode);
    }
}
