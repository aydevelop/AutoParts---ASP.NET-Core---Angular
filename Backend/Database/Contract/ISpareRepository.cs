using Database.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface ISpareRepository : IRepository<Spare>
    {
        Task<Spare[]> GetByFilterWithPaging(Expression<Func<Spare, bool>> criteria, int skip, int take, string sort = "");
        Task<Spare[]> GetByFilterWithModel(Expression<Func<Spare, bool>> criteria);
    }
}
