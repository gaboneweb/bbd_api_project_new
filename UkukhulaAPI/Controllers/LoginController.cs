using UkukhulaAPI.Data.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data.Services;
using UkukhulaAPI.Controllers.Request;
using UkukhulaAPI.Services;

namespace JWTLoginAuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly LoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config, UsersService usersService,LoginService loginService)
        {
            _userService = usersService;
            _loginService = loginService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] LoginVm userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = _loginService.GenerateToken(user);
                return Ok(new { token });
            }

            return NotFound("user not found");
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserRegistrationRequest userRegistrationRequest)
        {
           if(_userService.AddUser(userRegistrationRequest.User,userRegistrationRequest.userContact))
           {
            return Ok();

           }
            return BadRequest("unable to create user");
        }

        //To authenticate user
       private LoginVm? Authenticate(LoginVm userLogin)
        {
            var currentUsern = _userService.findUser(userLogin.Username);
            var userRole = _userService.FindUserRole(currentUsern);
            var password = "12345";
            if (currentUsern != null)
            {
                currentUsern.Password = password;
                currentUsern.Role = userRole;
                return currentUsern;
            }
            return null;
        }
    }
}