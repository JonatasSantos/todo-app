using api.Domain.TodoEntity;
using api.Domain.RepositoryInterface;
using api.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.RepositoryImplementation
{
    public class TodoRepository(AppDbContext context) : ITodoRepository
    {
        public async Task<Todo> AddAsync(Todo todo)
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await context.Todos.FindAsync(id);
            if (todo != null)
            {
                context.Todos.Remove(todo);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Todo>> GetAllAsync() => 
            await Task.FromResult(context.Todos.AsNoTracking().ToList());
        

        public async Task<Todo?> GetByIdAsync(int id) =>
         await context.Todos.FindAsync(id);
        

        public async Task UpdateAsync(Todo todo)
        {
            context.Todos.Update(todo);
            await context.SaveChangesAsync();
        }

    }
}
