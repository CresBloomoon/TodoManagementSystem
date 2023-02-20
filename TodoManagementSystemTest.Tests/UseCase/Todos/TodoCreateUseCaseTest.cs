using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Todos.Create;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Todos
{
    internal sealed class TodoCreateUseCaseTest : UseDbContextTestBase
    {
        private readonly TodoCreateUseCase _todoCreateUseCase;
        private readonly ITodoRepository _todoRepository;

        public TodoCreateUseCaseTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
            _todoCreateUseCase = new TodoCreateUseCase(_todoRepository);
        }

        [Test]
        public async Task 引数にタイトルなどを渡すと未完了状態でTODOが保存される()
        {
            //Arrange
            var userId = Guid.NewGuid().ToString("D");
            const string title = "タイトル";
            const string description = "詳細";

            //Act
            var command = new TodoCreateCommand(
                userSession: new UserSession(userId),
                title: title,
                description: description);
            var result = await _todoCreateUseCase.ExecuteAsync(command);

            //Assert
            var todo = await _todoRepository.FindAsync(new TodoId(result.Id));
            Assert.That(todo, Is.Not.Null);
            Assert.That(todo?.Status, Is.EqualTo(TodoStatus.InCompleted));
        }
    }
}
