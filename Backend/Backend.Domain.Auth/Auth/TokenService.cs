using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Domain.Auth.Auth;

public class TokenService
{
    private const string Secret = "br&Lp4y~\")w@qVBa/gSOr:665HW:<}0)e";
    
    public string Generate(int id, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, id.ToString()),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Typ, "at+jwt")
        };
        
        var token = new JwtSecurityToken(
            issuer: "https://marathon.com",
            audience: "marathon-api",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddSeconds(30),
            signingCredentials: credentials
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
    
    public bool Validate(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://marathon.com",
            ValidateAudience = true,
            ValidAudience = "marathon-api",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
            RequireSignedTokens = true
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        
        var userId = claims.FindFirst(ClaimTypes.NameIdentifier);

        return userId != null;
    }
}