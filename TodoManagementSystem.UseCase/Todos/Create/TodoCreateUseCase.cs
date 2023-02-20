using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystem.UseCase.Todos.Create
{
    public sealed class TodoCreateUseCase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoCreateUseCase(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoCreateResult> ExecuteAsync(TodoCreateCommand command)
        {
            var todo = Todo.CreateNew(
                title: new TodoTitle(command.Title),
                description: !string.IsNullOrWhiteSpace(command.Description)
                    ? new TodoDescription(command.Description)
                    : null,
                ownerId: new UserId(command.UserSession.Id));

            await _todoRepository.SaveAsync(todo);
            return new TodoCreateResult(todo.Id.Value);
        }
    }
}
