using System;
using System.Threading.Tasks;

namespace Database.Contract
{
    public interface IModelRepository : IRepository<Database.Model.Model>
    {
        Task<Database.Model.Model[]> GetBybrand(Guid id);
    }
}
