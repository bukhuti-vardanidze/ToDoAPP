using Azure.Core;
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
        private readonly IToDoRequestRepository _ToDoRequestRepository;

        public ToDoController(IToDoRequestRepository toDoRequestRepository)
        {
            _ToDoRequestRepository = toDoRequestRepository;
        }

        // Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ToDoCreateRequest toDoCreateRequest)
        {
            var entity = new ToDoEntity();
            entity.Title = toDoCreateRequest.Title;
            entity.Description = toDoCreateRequest.Description;
            entity.Deadline = toDoCreateRequest.Deadline;
           // var result = await toDoCreateRequest.Equals(entity);

            //if (!result.Succeeded)
            //{
            //    var firstError = result.Errors.First();
            //    return BadRequest(firstError.Description);
            //}

            return Ok();


        }

    }
}
