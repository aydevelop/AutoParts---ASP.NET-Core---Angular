using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class UserRegisterCommand : UserLoginCommand
    {
        [Required]
        public string UserName { get; set; }
    }
}
