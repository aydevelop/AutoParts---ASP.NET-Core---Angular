using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;

namespace AvtoZapchasti.Controllers
{
    public class CategoryController : CrudController<Category>
    {
        public CategoryController(ICategoryRepository db) : base(db)
        { }
    }
}
