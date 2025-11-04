using api.Application.MappingInterface;
using api.Application.TodoDTOs;
using api.Application.UseCaseInterface;
using api.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.UseCaseImplementation
{
    public class TodoService(ITodoRepository todoRepository, ITodoMapper todoMapper) : ITodoService
    {
        public async Task<TodoDTO> AddTodoAsync(CreateTodoDTO todoDTO)
        {
            var todo = todoMapper.MapToEntity(todoDTO);
            var createdTodo = await todoRepository.AddAsync(todo);
            return createdTodo == null ? throw new Exception("Failed to create todo") : todoMapper.MapToDTO(createdTodo);
        }

        public async Task DeleteTodoAsync(int id) => await todoRepository.DeleteAsync(id);
        
        public async Task<IEnumerable<TodoDTO>> GetAllTodosAsync()
        {
            var todos = await todoRepository.GetAllAsync();
            return todos.Select(todo => todoMapper.MapToDTO(todo)).ToList();
        }
        public async Task<TodoDTO?> GetTodoByIdAsync(int id)
        {
            var todo = await todoRepository.GetByIdAsync(id);
            return todo == null ? null : todoMapper.MapToDTO(todo);
        }

        public async Task UpdateTodoAsync(UpdateTodoDTO todoDTO)
        {
            var todo = todoMapper.MapToEntity(todoDTO);
            await todoRepository.UpdateAsync(todo);
        }
    }
}
