using AvtoZapchasti.Extensions;
using Database;
using Database.Contracts;
using Database.Model;
using Database.Repository;
using Infrastructure.Provider.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace AvtoZapchasti
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHostedService<HostedService>();
            services.AddDbContext<StoreDbContext>(q => q.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<StoreDbContext>().AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddTokenAuthentication(Configuration["keyjwt"]);
            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoreDbContext dbContext, ILoggerFactory loggerFactory)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwaggerDocumentation(env);
            loggerFactory.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\Log.txt");
        }
    }
}
