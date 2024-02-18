// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Security.Claims;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using System.IdentityModel.Tokens.Jwt;
// using Microsoft.Extensions.Configuration;
// using Microsoft.AspNetCore.Identity;


// namespace UkukhulaAPI.Data.Services;

// public class LoginService
// {


//     public LoginService(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }
//     public bool AuthenticateUser(string username, string password)
//     {

//         return true;
//     }

//     private string GenerateJwtToken(string username)
//     {
//         var tokenHandler = new JwtSecurityTokenHandler();
//         var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject = new ClaimsIdentity(new Claim[]
//             {
//                     new Claim(ClaimTypes.Name, username)
//             }),
//             Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
//             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//         };
//         var token = tokenHandler.CreateToken(tokenDescriptor);
//         return tokenHandler.WriteToken(token);
//     }

//     // Login request model
   

// }