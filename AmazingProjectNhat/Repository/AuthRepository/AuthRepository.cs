using AmazingProjectNhat.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmazingProjectNhat.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AuthenticateUser(UserLogin userLogin)
        {
            string response = "Username and Password Required.";
            if(userLogin == null || userLogin.Username == null || userLogin.Password == null)
            {
                return response;
            }
            if(userLogin.Username.Equals("admin") && userLogin.Password.Equals("123"))
            {
                response = GenerateJwtToken(userLogin, "Admin");
            }
            else if(userLogin.Username.Equals("manager") && userLogin.Password.Equals("123"))
            {
                response = GenerateJwtToken(userLogin, "Manager");
            }
            else
            {
                response = "Wrong Username or Password.";
            }
           
            return response;
        }
        public string GenerateJwtToken(UserLogin userLogin, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userLogin.Username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
