using Microsoft.Extensions.DependencyInjection;

namespace AvtoZapchasti.Extension
{
    public static class ApplicationPolicyExtensions
    {
        public static IServiceCollection AddPolicyServices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", "admin"));
            });

            return services;
        }
    }
}
