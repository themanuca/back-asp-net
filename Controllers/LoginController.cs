using APITESTE.Models;
using APITESTE.Repositories;
using APITESTE.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITESTE.Controllers{
    [ApiController]
    [Route("v1")]
    public class LoginController:ControllerBase{
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model){
            var user = UserRepository.Get(model.Username, model.Email);

            if(user == null){
                return  NotFound(new{message="Usuario não encontrado"});
            }

            var token = TokenService.GenerateToken(user, "login");
            return new {
                token = token,
                user = user
            };
        }
    }
}