using Database.Model;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public HomeController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("HomeController Index");
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> Categories()
        {
            var result = await categoryRepository.GetAll(); 
            return result;
        }
    }
}
