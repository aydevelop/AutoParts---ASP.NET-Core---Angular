using Database.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AvtoZapchasti.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("CategoryController Index");
        }
    }
}
