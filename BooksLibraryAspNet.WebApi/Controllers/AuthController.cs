using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("googleresponse")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return Unauthorized();

            return Redirect("http://localhost:5145/swagger");
        }
        
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var user = User.Claims.Select(c => new { c.Type, c.Value });
            return Ok(user);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logged out");
        }
    }
}