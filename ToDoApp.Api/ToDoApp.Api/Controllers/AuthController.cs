using Microsoft.AspNetCore.Mvc;

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


    }
}
