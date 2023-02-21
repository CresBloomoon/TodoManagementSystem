using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.UpdateStatus
{
    public sealed class TodoUpdateStatusUseCase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoUpdateStatusUseCase(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task ExecuteAsync(TodoUpdateStatusCommand command)
        {
            using var ts = new TransactionScope();

            var todo = await _todoRepository.FindAsync(new TodoId(command.Id));

            if (todo == null)
            {
                throw new UseCaseException("指定されたTODOが見つかりません。");
            }

            if (todo.OwnerId.Value != command.UserSession.Id)
            {
                throw new UseCaseException("指定されたTODOのステータスを更新する権限がありません。");
            }

            todo.UpdateStatus((TodoStatus)command.Status);

            await _todoRepository.SaveAsync(todo);

            ts.Complete();
        }
    }
}
