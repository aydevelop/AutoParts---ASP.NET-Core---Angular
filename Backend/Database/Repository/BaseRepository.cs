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
        private readonly AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        private async Task SaveAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
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
            _db.Add(entity);
            await SaveAsync();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).CountAsync();
        }

        public Task<int> Count()
        {
            return _db.Set<T>().CountAsync();
        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            await SaveAsync();
        }

        public Task<T[]> GetAll()
        {
            return _db.Set<T>().ToArrayAsync();
        }

        public async Task<T[]> GetByFiler(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).ToArrayAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}
