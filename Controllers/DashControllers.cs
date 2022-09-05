using APITESTE.Models;

using APITESTE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITESTE.Controllers{
    [ApiController]
    [Route("v1")]
    public class DashController: ControllerBase{
        [HttpGet]
        [Route("DashBoard")]
        [Authorize]
        public async Task<ActionResult<dynamic>> DashBoardGet(){
            return Ok("ACESSANDO A DASHBORD");
        }
    
        [HttpGet]
        [Route("CardUser")]
        [Authorize]
        public async Task<ActionResult<dynamic>> SecurityAcess([FromBody] User model ){
        
            var token = TokenService.GenerateToken(model, "whrite");
            var tokeS = TokenDecrypt.VerifyTokenTime(token);
            return new {
                token = token,
                tokeS = tokeS
            };
            
        }
    }



}