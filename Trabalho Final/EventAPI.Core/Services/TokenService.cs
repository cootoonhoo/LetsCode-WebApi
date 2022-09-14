using EventAPI.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventAPI.Core.Services
{
    public class TokenService : ITokenService
    {
        public IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateTokenEventAPI(string Name, string Permission) {
            
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "APIClientes.com",
                Audience = "APIEvents.com",
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, Name),
                    new Claim(ClaimTypes.Role, Permission)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
