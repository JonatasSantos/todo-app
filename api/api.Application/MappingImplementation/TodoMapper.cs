using api.Application.MappingInterface;
using api.Application.TodoDTOs;
using api.Domain.TodoEntity;


namespace api.Application.MappingImplementation
{
    internal class TodoMapper : ITodoMapper
    {
        public TodoDTO MapToDTO(Todo todo)
        {
            return new TodoDTO
            {
                Id = todo.Id,
                Task = todo.Task,
                IsCompleted = todo.IsCompleted
            };
        }

        public Todo MapToEntity(CreateTodoDTO createDTO)
        {
            return new Todo
            {
                Task = createDTO.Task,
                IsCompleted = createDTO.IsCompleted,
            };
        }

        public Todo MapToEntity(UpdateTodoDTO updateDTO)
        {
            return new Todo
            {
                Id = updateDTO.Id,
                Task = updateDTO.Task,
                IsCompleted = updateDTO.IsCompleted
            };
        }
    }
}
