using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    public class ModelController : CrudController<Model>
    {
        private readonly IModelRepository _db;

        public ModelController(IModelRepository db) : base(db)
        {
            this._db = db;
        }

        [HttpGet("getbybrand/{id:guid}")]
        public async Task<Model[]> GetBybrand(Guid id)
        {
            return await _db.GetBybrand(id);
        }
    }
}
