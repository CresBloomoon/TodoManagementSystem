using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Get
{
    public sealed class TodoGetUseCase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoGetUseCase(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoGetResult> ExecuteAsync(TodoGetCommand command)
        {
            var todo = await _todoRepository.FindAsync(new TodoId(command.Id));

            if (todo is null)
            {
                throw new UseCaseException("指定されたTODOが見つかりません。");
            }

            if (todo.OwnerId.Value != command.UserSession.Id)
            {
                throw new UseCaseException("指定されたTODOを表示する権限がありません。");
            }

            return new TodoGetResult(
                todo: new TodoData(
                    id: todo.Id.Value,
                    title: todo.Title.Value,
                    description: todo.Description?.Value ?? "",
                    status: (int)todo.Status,
                    statusName: todo.Status.ToString(),
                    createdDateTime: todo.CreatedDateTime));
        }
    }
}
