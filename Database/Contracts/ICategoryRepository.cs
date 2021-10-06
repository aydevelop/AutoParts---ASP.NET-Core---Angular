using Database.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Contracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}
