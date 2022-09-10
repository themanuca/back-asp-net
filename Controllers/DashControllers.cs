using APITESTE.Models;

using APITESTE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITESTE.Controllers
{
    [ApiController]
    [Route("v1")]
    public class DashController : ControllerBase
    {
        [HttpGet]
        [Route("DashBoard")]
        [Authorize]
        public async Task<ActionResult<dynamic>> DashBoardGet()
        {
            return Ok("ACESSANDO A DASHBORD");
        }

        [HttpGet]
        [Route("CardUser")]
        [Authorize]
        public async Task<ActionResult<dynamic>> SecurityAcess([FromBody] User model)
        {

            var token = TokenService.GenerateToken(model, "whrite");


            return token + "  5segundos";

        }
        public class ModeloString
        {
            public string key { get; set; }
        }

        [HttpPost]
        [Route("Editar")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Editar([FromBody] ModeloString token)
        {
            var tokeS = TokenDecrypt.VerifyTokenTime(token.key);

            return tokeS;

        }
    }



}