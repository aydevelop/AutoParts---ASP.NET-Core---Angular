using AutoMapper;
using AvtoZapchasti.Controllers.Base;
using AvtoZapchasti.Extension;
using Database;
using Database.Model;
using Infrastructure.DtoResponse;
using Infrastructure.Response.Auth;
using Infrastructure.User.Action;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthController(AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("AuthController Index");
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> RegisterAsync([FromBody] UserRegisterAction userRegisterAction)
        {
            var user = new AppUser { UserName = userRegisterAction.UserName, Email = userRegisterAction.Email };
            var result = await userManager.CreateAsync(user, userRegisterAction.Password);

            if (result.Succeeded)
            {
                return await userManager.GetTokenAsync<AppUser>(user.Email, configuration["keyjwt"]);
            }
            else
            {
                return BadRequest(Error(result.Errors.Select(q => q.Description)));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] UserLoginAction userLoginAction)
        {
            var user = await userManager.FindByEmailAsync(userLoginAction.Email);
            if (user == null)
            {
                return BadRequest(Error(new[] { "Incorrect Login" }));
            }

            var result = await signInManager.PasswordSignInAsync(user, userLoginAction.Password, true, false);
            if (result.Succeeded)
            {
                return await userManager.GetTokenAsync<AppUser>(userLoginAction.Email, configuration["keyjwt"]);
            }
            else
            {
                return BadRequest(Error(new[] { "Incorrect Login" }));
            }
        }

        [HttpPost("me")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<UserResponse> Me()
        {
            var email = HttpContext.User.FindFirst("email")?.Value;
            if (email == null) { return new UserResponse(); }

            var me = await userManager.FindByEmailAsync(email);
            var result = mapper.Map<AppUser, UserResponse>(me);

            return result;
        }
    }
}
