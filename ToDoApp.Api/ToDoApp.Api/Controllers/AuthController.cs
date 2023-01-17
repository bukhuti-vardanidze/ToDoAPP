﻿using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Auth;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private TokenGenerator _tokenGenerator;

        public AuthController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
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



        [HttpPost("login/{email}")]
        public string Login(string email)
        {
            // TODO:Check user credentials...



            return _tokenGenerator.Generate(email);
        }


    }
}
