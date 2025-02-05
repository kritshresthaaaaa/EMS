using Employee_Management_System.Application.DTOs.AuthDto;
using Employee_Management_System.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            if (Request.Cookies["access_token"] != null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                TempData["ErrorMessage"] = "Email and Password are required";
                return View("Index");
            }

            var result = _authService.AuthenticateAsync(request);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Error?.ErrorMessage ?? "Invalid credentials";
                return View("Index");
            }
            HttpContext.Response.Cookies.Append("access_token", result.Data.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpirationTimeInMinutes"]!))
            });
            return RedirectToAction("Index", "Employee");
        }

    }
}
