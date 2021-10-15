using Infrastructure.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtoZapchasti.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        [HttpGet]
        [HttpGet("valerror")]
        public IActionResult Error()
        {
            return new ObjectResult(new ValidationError { Errors = new[] { "The Name field is required" } });
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            return new ObjectResult(new BaseError(404));
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return new ObjectResult(new BaseError(400));
        }

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            object thing = null;
            return Ok(thing.ToString());
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }
    }
}
