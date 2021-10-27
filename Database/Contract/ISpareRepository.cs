using Database.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface ISpareRepository : IRepository<Spare>
    {
        Task<Spare[]> GetByFilerWithPaging(Expression<Func<Spare, bool>> criteria, int skip, int take, string sort = "");
    }
}
