using Database;
using Microsoft.AspNetCore.Mvc;

namespace AvtoZapchasti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly StoreDbContext _db;
        public BaseController(StoreDbContext db)
        {
            _db = db;
        }
    }
}
