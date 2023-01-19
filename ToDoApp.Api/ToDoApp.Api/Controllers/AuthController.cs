using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Auth;
using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Models.Requests;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private TokenGenerator _tokenGenerator;

        private UserManager<UserEntity> _userManager;

        public AuthController(TokenGenerator tokenGenerator, UserManager<UserEntity> userManager)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
        }

        [HttpPost("ping")]
        [HttpGet("ping")]
        public string Ping()
        {

            return "Pong";
        }


        // todo : register


        // todo : RequestPasswordReset


        // todo : ResetPassword

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody]RegisterUserRequest request)
        {
            var entity = new UserEntity();
            entity.Email = request.Email;
            var result = await _userManager.CreateAsync(entity,request.Password);
        }


        [HttpPost("login")]
        public string Login(string email)
        {
            // TODO:Check user credentials...



            return _tokenGenerator.Generate(email);
        }


    }
}
