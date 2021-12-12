using Database;
using Database.Model;
using Infrastructure.Error;
using Infrastructure.Response.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvtoZapchasti.Extension
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, String keyjwt)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyjwt)),
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;
                        var response = new ExceptionError(401, details: "You are not authorized");
                        var json = JsonSerializer.Serialize(response);
                        await context.Response.WriteAsync(json);
                    }
                };
            });

            return services;
        }

        public static async Task<AuthResponse> GetTokenAsync<T>(this UserManager<T> manager, string email, string site, String keyjwt) where T : IdentityUser
        {
            var claims = new List<Claim>() { new Claim("email", email), new Claim("site", site) };
            var user = await manager.FindByEmailAsync(email);
            if (user == null) { return new AuthResponse(); }

            var claimsDB = await manager.GetClaimsAsync(user);
            claims.AddRange(claimsDB);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyjwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMonths(1);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
