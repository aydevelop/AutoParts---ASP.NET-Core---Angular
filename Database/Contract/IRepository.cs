using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> GetAll();
        Task<T[]> GetByFiler(Expression<Func<T, bool>> predicate);
        Task<T[]> GetByFilerWithPaging(Expression<Func<T, bool>> predicate, int skip, int take);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<int> Count();
    }
}
