using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ToDoApp.Api.Auth;
using ToDoApp.Api.Db;
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
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db, TokenGenerator tokenGenerator, UserManager<UserEntity> userManager)
        {
             _db = db;
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
        }

        [HttpPost("ping")]
        [HttpGet("ping")]
        public string Ping()
        {

            return "Pong";
        }


        


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




        


        //RequestPasswordReset
        // 1 - validate token
        // 2 - validate new password
        // 3 re



        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody]RequestPasswordResetRequest request)
        {
            // 0 -  find user
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                return NotFound("User Not Found");

            }

            // 1 -  generate password reset token

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            // 2 -  insert email into sendEmailRequest table

            var sendEmailRequestEntity = new SendEmailRequestEntity();
            sendEmailRequestEntity.ToAdress = request.Email;
            sendEmailRequestEntity.Status = SendEmailRequestStatus.New;
            sendEmailRequestEntity.CreatedAt = DateTime.Now;
            var resetUrl = $" <a href=\"https://localhost:7261/api/Auth/reset-password/{token}\"> Reset Password</a>"
            sendEmailRequestEntity.Body = $"Hello, your password reset link is :{resetUrl} ";
            _db.SendEmailRequests.Add(sendEmailRequestEntity);
            await _db.SaveChangesAsync();

            // 3 -  return result
            return Ok();
            

        }

    }
}
