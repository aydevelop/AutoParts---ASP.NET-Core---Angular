using Database.Model;
using Infrastructure.ApiModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AvtoZapchasti.Util
{
    public class Security
    {
        public static async Task<AuthenticationResponse> BuildToken(string email, UserManager<AppUser> userManager, String keyjwt)
        {
            var claims = new List<Claim>() { new Claim("email", email) };
            var user = await userManager.FindByEmailAsync(email);
            var claimsDB = await userManager.GetClaimsAsync(user);
            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyjwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMonths(1);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
