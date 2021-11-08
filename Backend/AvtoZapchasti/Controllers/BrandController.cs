using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;

namespace AvtoZapchasti.Controllers
{
    public class BrandController : CrudController<Brand>
    {
        public BrandController(IRepository<Brand> db) : base(db)
        { }
    }
}
