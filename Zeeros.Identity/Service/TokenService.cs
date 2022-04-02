using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Zeeros.Identity.Models;

namespace Zeeros.Identity.Service
{
    public class TokenService : ITokenService
    {
        public string Issue(User user, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("name", user.UserName),
                new Claim("email", user.Email),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Secret").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenData = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                issuer: configuration.GetSection("Jwt:Issuer").Value,
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return jwt;
        }
    }
}
