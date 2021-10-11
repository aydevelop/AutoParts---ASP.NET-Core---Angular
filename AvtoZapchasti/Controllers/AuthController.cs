using AvtoZapchasti.Util;
using Database.Model;
using Infrastructure.ApiModel;
using Infrastructure.Command;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("AuthController Index");
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> RegisterAsync([FromBody] UserRegisterCommand userRegisterCommand)
        {
            var user = new AppUser { UserName = userRegisterCommand.UserName, Email = userRegisterCommand.Email };
            var result = await userManager.CreateAsync(user, userRegisterCommand.Password);

            if (result.Succeeded)
            {
                return await Security.BuildToken(user.Email, userManager, configuration["keyjwt"]);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserLoginCommand userLoginCommand)
        {
            var result = await signInManager.PasswordSignInAsync(userLoginCommand.Email, userLoginCommand.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return await Security.BuildToken(userLoginCommand.Email, userManager, configuration["keyjwt"]);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }
        }

        [HttpPost("me")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<AppUser> Me()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            if (email == null)
            {
                return new AppUser();
            }

            return await userManager.FindByEmailAsync(email);
        }
    }
}
