using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APITESTE.Models;
using Microsoft.IdentityModel.Tokens;

namespace APITESTE.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user, string actionUser)
        {

            if (actionUser == "login")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Setting.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            else if (actionUser == "whrite")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Setting.privateKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddMilliseconds(30000),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


                };

                var tokenWrite = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(tokenWrite);
            }


            return "ok";
        }



    }
}