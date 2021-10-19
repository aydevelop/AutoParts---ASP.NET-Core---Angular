using Infrastructure.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtoZapchasti.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        [HttpGet("validation-error")]
        public ActionResult Error()
        {
            return BadRequest(new ValidationError
            {
                Errors = new[] { "The Name field is required", "The Password field is required" }
            });
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundRequest()
        {
            return NotFound(Error());
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(Error());
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            object thing = null;
            return Ok(thing.ToString());
        }

        [Authorize]
        [HttpGet("test-auth")]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }
    }
}
