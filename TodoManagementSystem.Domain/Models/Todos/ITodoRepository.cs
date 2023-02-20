using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.Domain.Models.Todos
{
    public interface ITodoRepository
    {
        Task SaveAsync(Todo todo);
        Task<Todo?> FindAsync(TodoId id);
    }
}
