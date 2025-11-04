using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.TodoDTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
