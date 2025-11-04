using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.TodoDTOs
{
    public class CreateTodoDTO
    {
        public string? Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
