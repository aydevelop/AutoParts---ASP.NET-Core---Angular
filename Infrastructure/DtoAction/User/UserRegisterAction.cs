using System.ComponentModel.DataAnnotations;

namespace Infrastructure.User.Action
{
    public class UserRegisterAction : UserLoginAction
    {
        [Required]
        public string UserName { get; set; }
    }
}
