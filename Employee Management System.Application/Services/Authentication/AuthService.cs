using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.Common.Model.Error;
using Employee_Management_System.Application.DTOs.AuthDto;
using Employee_Management_System.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_Management_System.Application.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IEmployeeRepository employeeRepository, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
        }
        private string GenerateToken(string email, string password)
        {
            if (email == "testadmin@gmail.com" && password == "Admin@123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var description = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpirationTimeInMinutes"]))
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenCreator = tokenHandler.CreateJwtSecurityToken(description);
                var token = tokenHandler.WriteToken(tokenCreator);
                return token;
            }
            else
            {
                return null;
            }
        }

        public GenericResponse<AuthResponse> AuthenticateAsync(AuthRequestDto request)
        {
            var token = GenerateToken(request.Email, request.Password);
            if (token == null)
            {
                return new ErrorModel(System.Net.HttpStatusCode.BadRequest, "Invalid email or password");
            }
            var response = new AuthResponse
            {
                AccessToken = token,
                Email = request.Email,
                Role = "Admin"
            };
            return response;
        }

    }
}
