using AvtoZapchasti.Controllers.Base;
using Database.Contract;
using Database.Model;
using Database.Repository;

namespace AvtoZapchasti.Controllers
{
    public class CategoryController : CrudController<Category>
    {
        public CategoryController(ICategoryRepository db) : base(db)
        { }
    }
}
