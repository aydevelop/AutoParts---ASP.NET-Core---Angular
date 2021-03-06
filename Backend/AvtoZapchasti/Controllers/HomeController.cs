using AvtoZapchasti.Controllers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AvtoZapchasti.Controllers
{
    [Route("api")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Content("HomeControllerIndex");
        }

        [HttpGet("logs")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public ActionResult Logs([FromServices] IConfiguration Configuration)
        {
            var path = Path.Combine($"{Directory.GetCurrentDirectory()}", Configuration["logfile"]);
            var dir = Path.GetDirectoryName(path);
            var files = Directory.EnumerateFiles(dir, "*.txt");
            var logs = "";
            var filename = "";

            try
            {
                foreach (string item in files)
                {
                    filename = item;
                    logs += Environment.NewLine;
                    logs += Path.GetFileName(item) + Environment.NewLine;
                    logs += System.IO.File.ReadAllText(item) + Environment.NewLine;
                    logs += Environment.NewLine;
                }
            }
            catch (Exception)
            { }

            return Content(logs);
        }

    }
}
