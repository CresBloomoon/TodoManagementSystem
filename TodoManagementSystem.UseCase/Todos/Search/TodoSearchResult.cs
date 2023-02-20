using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Search
{
    public sealed class TodoSearchResult
    {
        public TodoSummaryData[] Summaries { get; }
        public int Total { get; }
        public int PageNum { get; }
        public int PageSize { get; }

        public TodoSearchResult(
            IEnumerable<TodoSummaryData>? summaries,
            int total,
            int pageNum,
            int pageSize)
        {
            Summaries = summaries?.ToArray() ?? Array.Empty<TodoSummaryData>();
            Total = total;
            PageNum = pageNum;
            PageSize = pageSize;
        }
    }
}
