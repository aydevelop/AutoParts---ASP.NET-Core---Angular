using Database.Contract;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<Category[]> Index()
        {
            return await _categoryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            await _categoryRepository.Add(category);
            return NoContent();
        }
    }
}
