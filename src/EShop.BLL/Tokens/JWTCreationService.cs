using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EShop.BLL.Tokens
{
    public class JwtCreationService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly SymmetricSecurityKey _signingKey;
        private readonly int _expirationMinutes;

        public JwtCreationService(string issuer, string audience, string signingKey, int expirationMinutes)
        {
            _issuer = issuer;
            _audience = audience;
            _signingKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey));
            _expirationMinutes = expirationMinutes;
        }

        public string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
