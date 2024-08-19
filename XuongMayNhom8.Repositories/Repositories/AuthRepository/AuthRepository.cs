using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XuongMayNhom8.Repositories.Configuration;
using XuongMayNhom8.Repositories.Context;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly XmbeContext _context;

        public AuthRepository(IConfiguration configuration, XmbeContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public string AuthenticateUser(UserLogin userLogin)
        {
            string response = "Username and Password Required.";
            if (userLogin == null || string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
            {
                return "Username and Password Required.";
            }
            var user = _context.Users.FirstOrDefault(u => u.Username == userLogin.Username && u.Password == userLogin.Password);
            if (user == null)
            {
                return "Wrong Username or Password.";
            }
            return GenerateJwtToken(user);
        }
        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
