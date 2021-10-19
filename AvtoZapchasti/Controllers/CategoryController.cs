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
        public async Task<ActionResult<Category>> GetById(Guid id)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null) { return NotFound(Error("Category not found")); }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            var result = await _categoryRepository.GetByFiler(q => q.Name == category.Name);
            if (result.Length > 0) { return BadRequest(Error("Сategory already exists ")); }

            await _categoryRepository.Add(category);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, Category category)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null) { return NotFound(Error("Category not found")); }

            category.Id = id;
            category.Name = null;
            await _categoryRepository.Update(category);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null) { return NotFound(Error("Category not found")); }

            await _categoryRepository.Delete(result);
            return NoContent();
        }
    }
}
