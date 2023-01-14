using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Auth;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route( "ping")]
        public string Ping()
        {
            return "pong";
        }


        [HttpPost("login")]
        public string Login(string email)
        {

            // todo: check user credentials


            var jwtSettings = new JwtSettings();

            jwtSettings.Audience = "";
            jwtSettings.Issuer = "";
            jwtSettings.SecrectKey="";


            var tokenGenrator = new TokenGenerator(jwtSettings);
            return tokenGenrator.Generate(email);
        }


    }
}
