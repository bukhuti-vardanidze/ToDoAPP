using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Models.Requests;
using ToDoApp.Api.Repositories;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private UserManager<UserEntity> _userManager;
        private readonly IToDoRepository _todoRepository;

        public ToDoController(UserManager<UserEntity> userManager, IToDoRepository toDoRepository)
        {
            _todoRepository = toDoRepository;
            _userManager = userManager;
        }

        // Create

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ToDoCreateRequest request)
        {
            // var entity = new ToDoEntity();
            // entity.Title = toDoCreateRequest.Title;
            // entity.Description = toDoCreateRequest.Description;
            // entity.Deadline = toDoCreateRequest.Deadline;
            //// var result = await toDoCreateRequest.Equals(entity);

            // //if (!result.Succeeded)
            // //{
            // //    var firstError = result.Errors.First();
            // //    return BadRequest(firstError.Description);
            // //}

            // return Ok();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User Not Found");
            }


            var userId = user.Id;
            await _todoRepository.InsertAsync(userId, request.Title, request.Description, request.Deadline);
            await _todoRepository.SaveChangesAsync();
            return Ok();


        }

    }
}
