using api.Application.TodoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.UseCaseInterface
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDTO>> GetAllTodosAsync();
        Task<TodoDTO?> GetTodoByIdAsync(int id);
        Task<TodoDTO> AddTodoAsync(CreateTodoDTO createDTO);
        Task UpdateTodoAsync(UpdateTodoDTO updateDTO);
        Task DeleteTodoAsync(int id);
    }
}
