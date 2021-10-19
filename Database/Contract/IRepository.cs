using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> GetAll();
        Task<T[]> GetByFiler(Expression<Func<T, bool>> predicate);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
