using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Edit
{
    public sealed class TodoEditUseCase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoEditUseCase(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task ExecuteAsync(TodoEditCommand command)
        {
            using var ts = new TransactionScope();

            var todo = await _todoRepository.FindAsync(new TodoId(command.Id));

            if (todo is null)
            {
                throw new UseCaseException("指定されたTODOが見つかりません。");
            }

            if (todo.OwnerId.Value != command.UserSession.Id)
            {
                throw new UseCaseException("指定されたTODOを編集する権限がありません。");
            }

            todo.Edit(
                title: new TodoTitle(command.Title),
                description: !string.IsNullOrWhiteSpace(command.Description)
                    ? new TodoDescription(command.Description)
                    : null);
                //beginDateTime: command.BeginDateTime,
                //dueDateTime: command.DueDateTime);

            await _todoRepository.SaveAsync(todo);

            ts.Complete();
        }
    }
}
