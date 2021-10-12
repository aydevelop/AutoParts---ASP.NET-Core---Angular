using Database;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    [Route("api")]
    public class HomeController : BaseController
    {
        public HomeController(StoreDbContext db) : base(db) { }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("HomeController Index");
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> Categories()
        {
            return await _db.Categories.ToArrayAsync();
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> Brands()
        {
            return await _db.Brands.ToArrayAsync();
        }

        [HttpGet("models")]
        public async Task<ActionResult<IEnumerable<Model>>> Models()
        {
            return await _db.Models.ToArrayAsync();
        }

        [HttpGet("spares")]
        public async Task<ActionResult<IEnumerable<Spare>>> Spares()
        {
            return await _db.Spares.ToArrayAsync();
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
    }
}
