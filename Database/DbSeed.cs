using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class DbSeed
    {
        public static async Task SeedAsync(StoreDbContext context)
        {
            if (!context.Brands.Any())
            {
                var brands = new List<Brand>
                {
                    new Brand
                    {
                        Id = Guid.NewGuid(),
                        Name = "Volkswagen"
                    },
                    new Brand
                    {
                        Id = Guid.NewGuid(),
                        Name = "Audi"
                    },
                    new Brand
                    {
                         Id = Guid.NewGuid(),
                        Name = "Mercedes"
                    },
                    new Brand
                    {
                        Id = Guid.NewGuid(),
                        Name = "BMW"
                    }
                };

                await context.Brands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
        }
    }
}
