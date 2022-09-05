using System.IdentityModel.Tokens.Jwt;

namespace APITESTE.Services{
    public static class TokenDecrypt{
        public static string VerifyTokenTime(string token){

            var stream = token;  
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var jti = tokenS.Claims.First(claim => claim.Type == "exp").Value;
            long l1 = (long)Convert.ToDouble(jti);
            DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds(l1);
            DateTime dateTime = dateTimeOffSet.DateTime;
            DateTime dateTokenUTC = dateTime.AddHours(-3);
            DateTime dateNow = DateTime.Now.AddSeconds(6);
            
            var dateToken = dateTokenUTC.ToString("HH:mm:ss");
            var dateNowToken = dateNow.ToString("HH:mm:ss");

            if(dateNowToken == dateToken){
                Console.WriteLine("Foi");
            }
           
            return dateToken  +"s"+  dateNowToken;
        }
    }
}