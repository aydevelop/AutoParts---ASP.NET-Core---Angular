using Database.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Database
{
    public class DbSeed
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<AppUser> manager)
        {
            if (!context.Brands.Any())
            {
                var brands = new List<Brand>
                {
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

            if (!context.Users.Any())
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                var user = new AppUser
                {
                    UserName = "user",
                    Email = "user@test.com"
                };

                await manager.CreateAsync(admin, "Pa$$w0rd");
                await manager.AddClaimAsync(admin, new Claim("role", "admin"));
                await manager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
