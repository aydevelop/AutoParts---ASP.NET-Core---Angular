﻿using Infrastructure.Error;
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
        public IActionResult Index()
        {
            return Content("HomeControllerIndex");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("logs")]
        public ActionResult Logs([FromServices] IConfiguration Configuration)
        {
            var path = Path.Combine($"{Directory.GetCurrentDirectory()}", Configuration["logfile"]);
            var dir = Path.GetDirectoryName(path);
            var logs = "";

            foreach (string item in Directory.EnumerateFiles(dir, "*.txt"))
            {
                logs += Path.GetFileName(item) + Environment.NewLine;
                logs += System.IO.File.ReadAllText(item) + Environment.NewLine;
                logs += Environment.NewLine;
            }

            return Content(logs);
        }

        [HttpGet("error")]
        public ActionResult Error([FromServices] IConfiguration Configuration)
        {
            return new ObjectResult(new ApiErrorResponse { Errors = new[] { "Test Error !!!" } });
        }
    }
}
