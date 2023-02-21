using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Todos.UpdateStatus;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Todos
{
    internal sealed class TodoUpdateStatusUseCaseTest : UseDbContextTestBase
    {
        private readonly TodoUpdateStatusUseCase _todoUpdateStatusUseCase;
        private readonly ITodoRepository _todoRepository;

        public TodoUpdateStatusUseCaseTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
            _todoUpdateStatusUseCase = new TodoUpdateStatusUseCase(_todoRepository);
        }

        [Test]
        public async Task 引数に状態を渡すとTODOの状態を更新して保存する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(status: TodoStatus.InCompleted);
            await _todoRepository.SaveAsync(todo);

            //Act
            var command = new TodoUpdateStatusCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value,
                status: (int)TodoStatus.Completed);
            await _todoUpdateStatusUseCase.ExecuteAsync(command);

            //Assert
            var updatedTodo = await _todoRepository.FindAsync(todo.Id);
            Assert.That(updatedTodo?.Status, Is.EqualTo(TodoStatus.Completed));
        }

        [Test]
        public void 存在しないTODOの状態を更新しようとすると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(status: TodoStatus.InCompleted);

            //Act
            //Assert
            var command = new TodoUpdateStatusCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value,
                status: (int)TodoStatus.Completed);
            Assert.That(
                async () => await _todoUpdateStatusUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }


        [Test]
        public async Task 他人が所有しているTODOの状態を更新しようとすると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(status: TodoStatus.InCompleted);
            await _todoRepository.SaveAsync(todo);

            var userId = Guid.NewGuid().ToString("D");

            //Act
            //Assert
            var command = new TodoUpdateStatusCommand(
                userSession: new UserSession(userId),
                id: todo.Id.Value,
                status: (int)TodoStatus.Completed);
            Assert.That(
                async () => await _todoUpdateStatusUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }
    }
}
