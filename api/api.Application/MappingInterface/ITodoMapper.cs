using api.Application.TodoDTOs;
using api.Domain.TodoEntity;

namespace api.Application.MappingInterface
{
    public interface ITodoMapper
    {
        TodoDTO MapToDTO(Todo task);
        Todo MapToEntity(CreateTodoDTO createDTO);
        Todo MapToEntity(UpdateTodoDTO updateDTO);
    }
}
