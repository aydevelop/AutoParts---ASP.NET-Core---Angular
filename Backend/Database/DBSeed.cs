using Database.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Database
{
    public class DbSeed
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<AppUser> manager)
        {
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

            if (!context.Spares.Any() && !context.Categories.Any())
            {
                string sql = File.ReadAllText("./../Database/data.sql");
                string[] batches = sql.Split(new[] { "\nGO" }, StringSplitOptions.None);
                foreach (string batch in batches)
                {
                    context.Database.ExecuteSqlRaw(batch);
                }
            }

            for (int i = 100; i <= 900; i += 100)
            {
                context.Models.Add(new Model.Model()
                {
                    Name = "m" + i,
                    BrandId = context.Brands.OrderBy(c => Guid.NewGuid())
                      .FirstOrDefault().Id
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
