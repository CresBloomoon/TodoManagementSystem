using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Search
{
    public interface ITodoSearchQueryService
    {
        Task<TodoSearchResult> ExecuteAsync(TodoSearchCommand command);
    }
}
