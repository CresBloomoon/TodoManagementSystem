using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Create
{
    public sealed class TodoCreateResult
    {
        public string Id { get; }
        public TodoCreateResult(string id)
        {
            Id = id;
        }
    }
}
