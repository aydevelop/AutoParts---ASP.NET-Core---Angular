using AvtoZapchasti.Extension;
using AvtoZapchasti.Middleware;
using Database;
using Database.Contract;
using Database.Repository;
using FluentValidation.AspNetCore;
using Infrastructure.Util;
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
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppDbContext>()); ;

            services.AddApplicationServices(Configuration);
            //services.AddHostedService<TaskRunner>();
            services.AddTokenAuthentication(Configuration["keyjwt"]);
            services.AddSwaggerDocumentation();
            services.AddCorsServices();
            services.AddPolicyServices();

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddAutoMapper(typeof(AutoMapperConfig));
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
