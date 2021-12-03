using Database.Contract;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class SpareRepository : BaseRepository<Spare>, ISpareRepository
    {
        private readonly AppDbContext _db;

        public SpareRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<Spare[]> GetByFilterWithPaging(Expression<Func<Spare, bool>> criteria, int skip, int take, out int total, bool isFull, string sort = "")
        {
            var query = _db.Spares.Where(criteria);
            if (sort == "priceAsk")
            {
                query = query.OrderBy(q => q.Price);
            }
            else if (sort == "priceDesc")
            {
                query = query.OrderByDescending(q => q.Price);
            }

            total = query.Count();
            if (isFull)
            {
                return query.Skip(skip).Take(take)
                    .Include(q => q.Category)
                    .Include(q => q.Model).ThenInclude(q => q.Brand)
                    .ToArrayAsync();
            }

            return query.Skip(skip).Take(take).ToArrayAsync();
        }

        public async Task<Spare[]> GetByFilterWithModel(Expression<Func<Spare, bool>> criteria)
        {
            return await _db.Spares.Where(criteria)
                .Include(m => m.Category)
                .Include(m => m.Model)
                .ThenInclude(b => b.Brand)
                .ToArrayAsync();
        }

        public async Task<Spare> GetWithDetails(Guid id)
        {
            return await _db.Spares
                .Include(q => q.Category)
                .Include(q => q.Model).ThenInclude(q => q.Brand)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
