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



        //

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("statusChanger")]
        public async Task<IActionResult> StatusChanger([FromBody] ToDoStatusChanger request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            await _todoRepository.StatusChangerAsync(request);
            await _todoRepository.SaveChangesAsync();
            return Ok();

        }


        //

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("InfoGiver")]
        public List<ToDoEntity> InfoGiver([FromBody] ToDoStatusChanger request)
        {
            var user =  _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound("User Not Found");
            //}


        }


        }
}
