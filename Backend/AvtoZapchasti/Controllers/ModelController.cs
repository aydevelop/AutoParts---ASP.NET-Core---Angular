using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;

namespace AvtoZapchasti.Controllers
{
    public class ModelController : CrudController<Model>
    {
        public ModelController(IRepository<Model> db) : base(db)
        { }
    }
}
