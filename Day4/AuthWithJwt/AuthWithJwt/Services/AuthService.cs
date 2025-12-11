using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthWithJwt.Services;

public class AuthService(IConfiguration _configuration)
{
    public string GenerateJwtToken(string username)
    {
        var jwtKey = _configuration["Jwt:Key"] ?? "YourSuperSecretKeyForJWTTokenGeneration12345";
        var jwtIssuer = _configuration["Jwt:Issuer"] ?? "TicketSystem";
        var jwtAudience = _configuration["Jwt:Audience"] ?? "TicketSystemUsers";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Surname, "Admin")
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
