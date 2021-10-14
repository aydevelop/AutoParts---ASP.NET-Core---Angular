using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Command
{
    public class UserLoginCommand
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
