using Database.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ModelRepository : BaseRepository<Database.Model.Model>, IModelRepository
    {
        private readonly AppDbContext _db;

        public ModelRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<Model.Model[]> GetBybrand(Guid id)
        {
            return _db.Models.Where(q => q.BrandId == id).ToArrayAsync();
        }
    }
}
