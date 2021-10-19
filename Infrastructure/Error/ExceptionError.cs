namespace Infrastructure.Error
{
    public class ExceptionError : BaseError
    {
        public string Details { get; set; }
        public ExceptionError(int statusCode = 500, string message = null, string details = null)
            : base(statusCode, message)
        {
            Details = details;
        }
    }
}
