using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Command
{
    public class UserRegisterCommand : UserLoginCommand
    {
        [Required]
        public string UserName { get; set; }
    }
}
