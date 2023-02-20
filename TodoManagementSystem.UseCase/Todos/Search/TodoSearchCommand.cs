using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Search
{
    public sealed class TodoSearchCommand
    {
        public UserSession UserSession { get; }
        public string? Keyword { get; }
        public int[] Statuses { get; }
        public int PageNum { get; }
        public int PageSize { get; }

        public TodoSearchCommand(
            UserSession userSession,
            string? keyword = null,
            IEnumerable<int>? statuses = null,
            int pageNum = 1,
            int pageSize = 30)
        {
            UserSession = userSession;
            Keyword = keyword;
            Statuses = statuses?.ToArray() ?? Array.Empty<int>();
            PageNum = pageNum;
            PageSize = pageSize;
        }
    }
}
