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
using System.Security.Claims;
using System.Threading.Tasks;

namespace AvtoZapchasti.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("AuthController Index");
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> RegisterAsync([FromBody] UserRegisterAction userRegisterAction)
        {
            var user = new AppUser
            {
                UserName = userRegisterAction.UserName,
                Email = userRegisterAction.Email,
                SiteUrl = userRegisterAction.Site
            };

            var result = await _userManager.CreateAsync(user, userRegisterAction.Password);
            await _userManager.AddClaimAsync(user, new Claim("role", "user"));

            if (result.Succeeded)
            {
                string site = user.SiteUrl ?? "";
                return await _userManager.GetTokenAsync<AppUser>(user.Email, site, _configuration["keyjwt"]);
            }
            else
            {
                return BadRequest(Error(result.Errors.Select(q => q.Description)));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] UserLoginAction userLoginAction)
        {
            var user = await _userManager.FindByEmailAsync(userLoginAction.Email);
            if (user == null)
            {
                return BadRequest(Error(new[] { "Incorrect Login" }));
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginAction.Password, true, false);
            if (result.Succeeded)
            {
                string site = user.SiteUrl ?? "";
                return await _userManager.GetTokenAsync<AppUser>(userLoginAction.Email, site, _configuration["keyjwt"]);
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

            var me = await _userManager.FindByEmailAsync(email);
            var result = _mapper.Map<AppUser, UserResponse>(me);

            return result;
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
