using Infrastructure.Error;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AvtoZapchasti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ExceptionError Error(string details = null, string message = null)
        {
            return new ExceptionError(message: message, details: details);
        }

        protected ValidationError Error(IEnumerable<string> Errors)
        {
            return new ValidationError { Errors = Errors };
        }
    }
}
