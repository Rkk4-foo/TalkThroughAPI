using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TalkThroughAPI.Services
{
    public class JwtService : Interfaces.IJwtService
    {
        private readonly string _apiKey;
        public JwtService(IConfiguration configuration) 
        {
            _apiKey = configuration["Jwt:Secret"];
        }
        public string GenerateToken(string userId, string username, int expireHours = 2)
        {
            var tokenhandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_apiKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(expireHours),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
