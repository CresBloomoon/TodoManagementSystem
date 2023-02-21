using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Get
{
    public sealed class TodoGetResult
    {
        public TodoData Todo { get; }

        public TodoGetResult(TodoData todo)
        {
            Todo = todo;
        }
    }
}
