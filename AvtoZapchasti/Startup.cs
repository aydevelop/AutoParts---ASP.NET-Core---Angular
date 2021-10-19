using AvtoZapchasti.Extension;
using AvtoZapchasti.Middleware;
using Database;
using Database.Contract;
using Database.Repository;
using Infrastructure.Provider.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

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
            services.AddApplicationServices(Configuration);
            services.AddHostedService<TaskRunner>();
            services.AddTokenAuthentication(Configuration["keyjwt"]);
            services.AddSwaggerDocumentation();
            services.AddCorsServices();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwaggerDocumentation(env);
            app.UseCorsServices();
        }
    }
}
