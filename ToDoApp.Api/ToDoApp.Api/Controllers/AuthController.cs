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
             
            if(!result.Succeeded)
            {
                var firstError =  result.Errors.First();
                return BadRequest(firstError.Description);
            }

            return Ok();
        
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var user =  await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("User Not Found!");

            }

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if(!isCorrectPassword)
            {
                return BadRequest("Invalid Email or Password");
            }  
             
            return Ok(_tokenGenerator.Generate(request.Email));
        }


        [HttpPost("passwordReset")]
        public async Task<IActionResult> PasswordReset([FromBody]ResetPasswordRequest resetPassword)
        {

            //..


            return Ok();
        }

    }
}
