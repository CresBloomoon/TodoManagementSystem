using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Todos.Edit;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Todos
{
    internal sealed class TodoEditUseCaseTest : UseDbContextTestBase
    {
        private readonly TodoEditUseCase _todoEditUseCase;
        private readonly ITodoRepository _todoRepository;

        public TodoEditUseCaseTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
            _todoEditUseCase = new TodoEditUseCase(_todoRepository);
        }

        [Test]
        public async Task 引数にタイトルと詳細を渡すと更新して保存する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                title: "タイトル",
                description: "説明文");
            await _todoRepository.SaveAsync(todo);

            const string newTitle = "NewTitle";
            const string newDescription = "NewDescription";

            //Act
            var command = new TodoEditCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value,
                title: newTitle,
                description: newDescription);
            await _todoEditUseCase.ExecuteAsync(command);

            //Assert
            var editedTodo = await _todoRepository.FindAsync(todo.Id);
            Assert.That(editedTodo?.Title.Value, Is.EqualTo(newTitle));
            Assert.That(editedTodo?.Description.Value, Is.EqualTo(newDescription));
        }

        [Test]
        public void 存在しないTODOを編集すると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                title: "タイトル",
                description: "説明文");

            const string newTitle = "新しいタイトル";
            const string newDescription = "新しい説明文";

            //Act
            //Assert
            var command = new TodoEditCommand(
                userSession: new UserSession(todo.OwnerId.Value),
                id: todo.Id.Value,
                title: newTitle,
                description: newDescription);

            Assert.That(
                async () => await _todoEditUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }

        [Test]
        public async Task 他のユーザーのTODOを編集しようとすると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                title: "タイトル",
                description: "説明文",
                isDeleted: true);
            await _todoRepository.SaveAsync(todo);

            const string newTitle = "新しいタイトル";
            const string newDescription = "新しい説明文";

            var userId = Guid.NewGuid().ToString();

            //Act
            //Assert
            var command = new TodoEditCommand(
                userSession: new UserSession(userId),
                id: todo.Id.Value,
                title: newTitle,
                description: newDescription);

            Assert.That(
                async () => await _todoEditUseCase.ExecuteAsync(command),
                Throws.TypeOf<UseCaseException>());
        }
    }
}
