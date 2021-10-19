using System.ComponentModel.DataAnnotations;

namespace Infrastructure.User.Action
{
    public class UserLoginAction
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
