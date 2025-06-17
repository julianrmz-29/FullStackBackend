using Microsoft.AspNetCore.Mvc;
using ToDoBackend.AppServices;
using ToDoBackend.Models;
using ToDoBackend.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoAppService _todoAppService;

        public TodoController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodo()
        {
            var response = await _todoAppService.GetAllTodoAsync();
            return Ok(response);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostTodo( ToDoAddEditDTO todoModel)
        {
            var response = await _todoAppService.AddTodoAsync(todoModel);
            if (!response.Success)
            {
                if (response.Message.Contains("An error")){
                    return StatusCode(500, response);
                }
                return BadRequest(response);
            }                
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, ToDoAddEditDTO todoModel)
        {
            var response = await _todoAppService.UpdateTodoAsync(id, todoModel);
            if (!response.Success)
            {
                if (response.Message.Contains("An error"))
                {
                    return StatusCode(500, response);
                }
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var response = await _todoAppService.DeleteTodoAsync(id);
            if (!response.Success)
            {
                if (response.Message.Contains("An error"))
                {
                    return StatusCode(500, response);
                }
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
