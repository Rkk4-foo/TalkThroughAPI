using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TalkThroughAPI.Services
{

    /// <summary>
    /// TODO : Adding a function to refresh tokens in order to let the user keep their session online.
    /// Service used for anything token related inside the API. There are 3 differet audiences in production. 
    /// For development purposes, there is a DefaultAudience in order to test the API.
    /// </summary>
    public class JwtService : Interfaces.IJwtService
    {
        private readonly string _apiKey;
        private readonly string _issuer;
        private readonly string _defaultAudience;
        public JwtService(IConfiguration configuration) 
        {
            _apiKey = configuration["Jwt:Key"] ?? throw new Exception("Token key not found in configuration");
            _issuer = configuration["Jwt:Issuer"] ?? throw new Exception("Issuer not found");
            _defaultAudience = configuration["Jwt:DefaultAudience"] ?? throw new Exception("Audience not found or not valid");
        }
        public string GenerateToken(string userId, string username, int expireHours = 2)
        {
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken 
            (
                issuer : _issuer,
                audience : _defaultAudience,
                claims : claims,
                expires : DateTime.Now.AddHours(expireHours),
                signingCredentials : creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
