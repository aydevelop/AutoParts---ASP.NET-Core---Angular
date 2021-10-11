using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AvtoZapchasti.Extensions
{
    public static class TokenAuthExtensions
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, String keyjwt)
        {
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
            });

            return services;
        }

        //public static async Task<AuthenticationResponse> GetTokenAsync(this UserManager<IdentityUser> manager, string email, String keyjwt)
        //{
        //    var claims = new List<Claim>() { new Claim("email", email) };
        //    var user = await manager.FindByEmailAsync(email);
        //    var claimsDB = await manager.GetClaimsAsync(user);
        //    claims.AddRange(claimsDB);

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyjwt));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var expiration = DateTime.UtcNow.AddMonths(1);
        //    var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
        //        expires: expiration, signingCredentials: creds);

        //    return new AuthenticationResponse()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
        //        Expiration = expiration
        //    };
        //}
    }
}
