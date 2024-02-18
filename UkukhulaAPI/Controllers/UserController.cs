using UkukhulaAPI.Data.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using UkukhulaAPI.Data.Services;


namespace JWTLoginAuthenticationAuthorization.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    private ApplicationsService _applications;
    public UserController(ApplicationsService service)
    {
        _applications = service;
    }
        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Role}");
        }
        private LoginVm GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new LoginVm
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
        [HttpGet]
        [Route("Admins/viewApplications")]
        // [Authorize(Roles = "Admin")]
        public IActionResult AdminApplicationsEndPoint()
        {
            return Ok(_applications.GetApplications());
        }




    }
