using Database.Contract;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers.Base
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public abstract class CrudController<T> : BaseController where T : BaseEntity
    {
        private readonly IRepository<T> _db;
        private readonly Type _type;

        public CrudController(IRepository<T> db)
        {
            _db = db;
            _type = typeof(T);
        }

        [HttpGet]
        public virtual async Task<T[]> GetAll()
        {
            return await _db.GetAll();
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<T>> GetById(Guid id)
        {
            var result = await _db.GetById(id);
            if (result == null) { return NotFound(Error($"{_type.Name} not found")); }

            return result;
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(T category)
        {
            await _db.Add(category);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public virtual async Task<ActionResult> Put(Guid id, T category)
        {
            var result = await _db.GetById(id);
            if (result == null) { return NotFound(Error($"{_type.Name} not found")); }

            category.Id = id;
            await _db.Update(category);
            return NoContent();
        }

        [HttpDelete]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var result = await _db.GetById(id);
            if (result == null) { return NotFound(Error($"{_type.Name} not found")); }

            await _db.Delete(result);
            return NoContent();

        }
    }
}
