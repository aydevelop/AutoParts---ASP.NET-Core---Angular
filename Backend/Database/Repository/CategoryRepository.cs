using Database.Contract;
using Database.Model;

namespace Database.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db)
        { }
    }
}
