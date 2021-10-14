using System.Collections.Generic;

namespace Infrastructure.Error
{
    public class ApiErrorResponse : ApiResponse
    {
        public ApiErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
