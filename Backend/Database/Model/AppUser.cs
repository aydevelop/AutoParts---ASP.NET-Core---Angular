using Microsoft.AspNetCore.Identity;

namespace Database.Model
{
    public class AppUser : IdentityUser
    {
        public string SiteUrl { get; set; }
    }
}
