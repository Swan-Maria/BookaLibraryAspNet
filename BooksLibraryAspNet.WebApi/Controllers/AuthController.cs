using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibraryAspNet.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        AuthenticationProperties properties = new()
        {
            RedirectUri = "/auth/callback",
            AllowRefresh = true
        };

        if (User.Identity?.IsAuthenticated == true)
        {
            return Redirect("/auth/callback");
        }

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("callback")]
    public async Task<IActionResult> SignInCallback()
    {
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (result.Succeeded != true)
        {
            return Unauthorized();
        }

        var principal = result.Principal;
        if (principal.Identity is ClaimsIdentity claimsIdentity)
        {
            // Добавила проверку, есть ли уже у пользователя Role со значением "User",
            // потому что при каждом выполнении /auth/login в текущей сессии добавлялся дубликат Role=="User" 
            // хотя в принципе врядли кто-нибудь будет вводить /auth/login, когда уже вошел... но я вводила
            if (!claimsIdentity.Claims.Any(c => c is { Type: ClaimTypes.Role, Value: "User" }))
            {
                claimsIdentity.AddClaim(new(ClaimTypes.Role, "User"));
            }
        }

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            result.Properties);

        return Redirect("/swagger");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        var accessToken = await HttpContext.GetTokenAsync("access_token");

         if (accessToken != null)
        {
            using var client = _httpClientFactory.CreateClient();
            await client.PostAsync($"https://oauth2.googleapis.com/revoke?token={accessToken}", null);
        }

        return Redirect("/auth/login");
    }

    [HttpGet("user")]
    public IActionResult GetUser()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return Ok(new
            {
                name = User.Identity.Name,
                claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
        return Unauthorized();
    }
}