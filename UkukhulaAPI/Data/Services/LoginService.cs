using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Services
{
    public class LoginService
    {
        private readonly IConfiguration _configuration;
        private readonly string _tokenSecret;

        public LoginService(IConfiguration configuration)
        {
            // _configuration = configuration;
            _tokenSecret = configuration["JwtSettings:Key"];
        }

        public string GenerateToken(LoginVm user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_tokenSecret);
            var isAdmin = user.Role == "Admin" ? true : false;
            var isHOD = user.Role == "HOD" ? true : false;
            var isStudent = user.Role == "Student" ? true : false;
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                isAdmin ? new Claim(ClaimTypes.Role, "Admin") : null,
                isHOD ? new Claim(ClaimTypes.Role, "HOD") : null
               
            };

             claims.RemoveAll(c => c == null);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience="http://localhost:5263/",
                Issuer="http://localhost:5263/",
                Expires = DateTime.UtcNow.AddMinutes(40), // Set token expiration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
