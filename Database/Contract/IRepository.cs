using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> GetAll();
        IEnumerable<T> GetByFiler(Func<T, bool> predicate);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
