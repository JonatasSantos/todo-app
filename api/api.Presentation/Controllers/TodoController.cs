using api.Application.TodoDTOs;
using api.Application.UseCaseInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ITodoService todoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDTO createTodoDTO)
        {
            TodoDTO todoCreated = await todoService.AddTodoAsync(createTodoDTO);
            return CreatedAtAction(nameof(GetById), new { id = todoCreated.Id }, todoCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoDTO updateTodoDTO)
        {
            if (id != updateTodoDTO.Id)
            {
                return BadRequest();
            }
            await todoService.UpdateTodoAsync(updateTodoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}
