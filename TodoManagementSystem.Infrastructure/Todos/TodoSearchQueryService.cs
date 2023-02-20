using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.DataModels;
using TodoManagementSystem.UseCase.Todos.Search;

namespace TodoManagementSystem.Infrastructure.Todos
{
    public sealed class TodoSearchQueryService : ITodoSearchQueryService
    {
        private readonly AppDbContext _dbContext;

        public TodoSearchQueryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodoSearchResult> ExecuteAsync(TodoSearchCommand command)
        {
            var ownTodos = _dbContext.Todos
                .Where(x => x.OwnerId == command.UserSession.Id)
                .Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(command.Keyword))
            {
                ownTodos = ownTodos.Where(x =>
                    x.Title.Contains(command.Keyword, StringComparison.OrdinalIgnoreCase) ||
                    x.Description != null &&
                    x.Description.Contains(command.Keyword, StringComparison.OrdinalIgnoreCase));
            }

            if (command.Statuses.Any())
            {
                ownTodos = ownTodos.Where(x => command.Statuses.Contains(x.Status));
            }

            var filteredTodos = await ownTodos.ToArrayAsync();

            var pageNum = Math.Max(command.PageNum, 1);
            var pageSize = Math.Min(Math.Max(command.PageSize, 1), 30);

            return new TodoSearchResult(
                summaries: filteredTodos
                    .OrderByDescending(x => x.CreatedDateTime)
                    .Skip((pageNum - 1) * command.PageSize)
                    .Take(pageSize)
                    .Select(x => new TodoSummaryData(
                        id: x.Id,
                        title: x.Title,
                        createdDatetime: x.CreatedDateTime,
                        updatedDateTime: x.UpdatedDateTime,
                        statusString: ((TodoStatus)x.Status).ToString())),
                total: filteredTodos.Length,
                pageNum: pageNum,
                pageSize: pageSize);

        }
    }
}
