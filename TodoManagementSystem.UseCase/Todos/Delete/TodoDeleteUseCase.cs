using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Delete
{
    public sealed class TodoDeleteUseCase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoDeleteUseCase(ITodoRepository todoRepository)
        {
            _todoRepository= todoRepository;
        }

        public async Task ExecuteAsync(TodoDeleteCommand command)
        {
            using var ts = new TransactionScope();
            var todo = await _todoRepository.FindAsync(new TodoId(command.Id));

            if (todo is null) throw new UseCaseException("指定されたTODOが見つかりません");

            if (todo.OwnerId.Value != command.UserSession.Id)
            {
                throw new UseCaseException("指定されたTODOを削除する権限がありません");
            }

            todo.Delete();

            await _todoRepository.SaveAsync(todo);

            ts.Complete();
        }
    }
}
