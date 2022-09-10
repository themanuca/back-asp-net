using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using APITESTE.Models;
namespace APITESTE.Services
{
    public static class TokenDecrypt
    {
        public static string VerifyTokenTime(string token)
        {
            var key = Encoding.ASCII.GetBytes(Setting.privateKey);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims.Identity.Name;

            //     var tokenValidationParameters = new TokenValidationParameters
            //     {

            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Setting.privateKey)),
            //         ValidateIssuer = false,
            //         ValidateAudience = false,
            //     };

            //     var tokenHandler = new JwtSecurityTokenHandler();
            //     var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            //     if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            //         !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
            //     {

            //         return "Invalid Token";
            //     }





            //     return "Token Valido";
            // }
        }
    }
}