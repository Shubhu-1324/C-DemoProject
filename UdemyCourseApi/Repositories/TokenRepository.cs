using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UdemyCourseApi.Repositories
{
    public class TokenRepository(IConfiguration configuration) : ITokenRepository
    {
        public IConfiguration Configuration { get; } = configuration;

        public string createJWTToken(IdentityUser user, List<string> roles)
        {
            if (user?.Email == null || roles == null || roles.Count == 0)
            {
                throw new ArgumentException("User or roles cannot be null.");
            }

            var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, user.Email ?? "default@example.com") // Default if email is null
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role ?? "default_role")); // Default if role is null
            }

            var jwtKey = Configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = signingCredentials,
                Issuer = Configuration["Jwt:Issuer"],
                Audience = Configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
