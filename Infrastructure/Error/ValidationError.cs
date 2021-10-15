using System.Collections.Generic;

namespace Infrastructure.Error
{
    public class ValidationError : BaseError
    {
        public ValidationError() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
