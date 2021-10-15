using Infrastructure.Error;
using Microsoft.AspNetCore.Mvc;

namespace AvtoZapchasti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ExceptionError E(int statusCode, string message = null, string details = null)
        {
            return new ExceptionError(statusCode, message, details);
        }
    }
}
