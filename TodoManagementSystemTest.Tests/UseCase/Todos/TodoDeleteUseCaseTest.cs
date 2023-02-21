using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Todos.Delete;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Todos
{
    internal sealed class TodoDeleteUseCaseTest : UseDbContextTestBase
    {
        private readonly TodoDeleteUseCase _todoDeleteUseCase;
        private readonly ITodoRepository _todoRepository;

        public TodoDeleteUseCaseTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
            _todoDeleteUseCase = new TodoDeleteUseCase(_todoRepository);
        }

        [Test]
        public async Task IDを指定して削除すると削除フラグを立てて保存する()
        {
            //Arrange
            var todo = TodoGenerator.Generate();
            await _todoRepository.SaveAsync(todo);

            //Act
            var command = new TodoDeleteCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value);
            await _todoDeleteUseCase.ExecuteAsync(command);

            //Assert
            var deletedTodo = await _todoRepository.FindAsync(todo.Id);
            Assert.That(deletedTodo?.IsDeleted, Is.True);
            Assert.That(deletedTodo?.DeletedDateTime, Is.Not.Null);
        }

        [Test]
        public void 存在しないTODOを指定して削除すると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate();

            //Act
            var command = new TodoDeleteCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value);

            //Assert
            Assert.That(
                async () => await _todoDeleteUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }

        [Test]
        public async Task 他人が所有するTODOを指定して削除しようとすると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate();
            await _todoRepository.SaveAsync(todo);

            //他人のIDを生成
            var userId = Guid.NewGuid().ToString("D");

            //Act
            var command = new TodoDeleteCommand(
                userSession: new UserSession(userId),
                id: todo.Id.Value);

            //Assert
            Assert.That(
                async () => await _todoDeleteUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());

        }
    }
}
