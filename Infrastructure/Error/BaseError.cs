namespace Infrastructure.Error
{
    public abstract class BaseError
    {
        public string Message { get; }

        public BaseError(int statusCode, string message = null)
        {
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request cannot be fulfilled due to bad syntax",
                401 => "The request requires user authentication",
                403 => "The server understood the request, but is refusing to fulfill it",
                404 => "The server has not found anything matching the Request-URI",
                500 => "The server encountered an unexpected condition which prevented it from fulfilling the request",
                _ => "Null error"
            };
        }
    }
}
