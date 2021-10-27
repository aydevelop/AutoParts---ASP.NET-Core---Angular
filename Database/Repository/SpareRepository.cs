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
        private readonly AppDbContext _context;

        public SpareRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Spare[]> GetByFilerWithPaging(Expression<Func<Spare, bool>> criteria, int skip, int take, string sort = "")
        {
            var query = _context.Spares.Where(criteria);
            if (sort == "priceAsk")
            {
                query = query.OrderBy(q => q.Price);
            }
            else if (sort == "priceDesc")
            {
                query = query.OrderByDescending(q => q.Price);
            }

            return query.Skip(skip).Take(take).ToArrayAsync();
        }
    }
}
