using AvtoZapchasti.Extension;
using AvtoZapchasti.Middleware;
using Database;
using Database.Contract;
using Database.Repository;
using FluentValidation.AspNetCore;
using Infrastructure.Provider.Base;
using Infrastructure.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

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
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppDbContext>())
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

            services.AddDbContext<AppDbContext>(q => q.UseSqlServer(Configuration.GetConnectionString("DefConnection")));
            services.AddApplicationServices(Configuration);
            services.AddTokenAuthentication(Configuration["keyjwt"]);
            services.AddSwaggerDocumentation();
            services.AddCorsServices();
            services.AddPolicyServices();

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISpareRepository, SpareRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddHostedService<TaskRunner>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseCorsServices();

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
