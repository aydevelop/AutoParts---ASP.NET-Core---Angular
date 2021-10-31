using Database.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

        private async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // https://msdn.microsoft.com/en-in/data/jj592904.aspx
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
            }
        }

        public async Task Add(T entity)
        {
            _context.Add(entity);
            await SaveAsync();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).CountAsync();
        }

        public Task<int> Count()
        {
            return _context.Set<T>().CountAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public Task<T[]> GetAll()
        {
            return _context.Set<T>().ToArrayAsync();
        }

        public async Task<T[]> GetByFiler(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToArrayAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}
