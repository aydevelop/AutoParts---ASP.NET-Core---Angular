using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext context;

        public CategoryRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
