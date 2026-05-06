using KeyPass_Sabitov.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace KeyPass_Sabitov.Classes
{
    public class JwtToken
    {
        static byte[] Key = Encoding.UTF8.GetBytes("Beta");
        public static string Generate(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new ();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature
                 )
            };
            SecurityToken Token = tokenHandler.CreateToken (tokenDescriptor);
            return tokenHandler.WriteToken(Token);
        }
        public static int? GetUserIdFromToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
                TokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                JwtSecurityToken jwtSecurity = (JwtSecurityToken)validatedToken;
                string userId = jwtSecurity.Claims.First(x => x.Type == "UserId").Value;
                return int.Parse(userId);
            }
            catch
            {
                return null;
            }
        }
    }
}
