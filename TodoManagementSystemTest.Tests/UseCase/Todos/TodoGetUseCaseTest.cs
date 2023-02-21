using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Todos.Get;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Todos
{
    internal sealed class TodoGetUseCaseTest : UseDbContextTestBase
    {
        private readonly TodoGetUseCase _todoGetUseCase;
        private readonly ITodoRepository _todoRepository;

        public TodoGetUseCaseTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
            _todoGetUseCase = new TodoGetUseCase(_todoRepository);
        }

        [Test]
        public async Task TODOのIDを指定して詳細を取得する()
        {
            //Arrange
            var todo = TodoGenerator.Generate();
            await _todoRepository.SaveAsync(todo);

            //Act
            var command = new TodoGetCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value);
            var result = await _todoGetUseCase.ExecuteAsync(command);

            //Assert
            Assert.That(result.Todo.Id, Is.EqualTo(todo.Id.Value));
            Assert.That(result.Todo.Title, Is.EqualTo(todo.Title.Value));
            Assert.That(result.Todo.Description, Is.EqualTo(todo.Description?.Value));
            Assert.That(result.Todo.CreatedDateTime, Is.EqualTo(todo.CreatedDateTime));
            Assert.That(result.Todo.Status, Is.EqualTo((int)todo.Status));
            Assert.That(result.Todo.StatusName, Is.EqualTo(todo.Status.ToString()));
        }

        [Test]
        public void 存在しないTODOのIDを指定すると例外が発生する()
        {
            //Arrange
            var userId = Guid.NewGuid().ToString();
            var todoId = TodoId.Generate().Value;

            //Act
            //Assert
            var command = new TodoGetCommand(
                userSession: new UserSession(userId),
                id: todoId);

            Assert.That(
                async () => await _todoGetUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }

        [Test]
        public async Task 他のユーザー所有するTODOのIDを指定すると例外が発生する()
        {
            //Arrange
            var userId = Guid.NewGuid().ToString();

            var todo = TodoGenerator.Generate();
            await _todoRepository.SaveAsync(todo);

            //Act
            //Assert
            var command = new TodoGetCommand(
                userSession: new UserSession(userId),
                id: todo.Id.Value);

            Assert.That(
                async () => await _todoGetUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }
    }
}
