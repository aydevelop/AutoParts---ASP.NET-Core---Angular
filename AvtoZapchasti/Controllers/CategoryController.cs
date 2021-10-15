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
        public async Task<Category[]> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
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


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, Category category)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null) { return NotFound(E(404)); }

            category.Id = id;
            category.Name = null;
            await _categoryRepository.Update(category);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null) { return NotFound(E(404)); }

            await _categoryRepository.Delete(result);
            return NoContent();
        }
    }
}
