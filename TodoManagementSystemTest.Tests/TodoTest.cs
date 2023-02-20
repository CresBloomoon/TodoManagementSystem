using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystemTest.Tests.Helpers;

namespace TodoManagementSystemTest.Tests
{
    public class TodoTest
    {
        [Test]
        public void 新しくTODOを作成すると未完了状態でインスタンスが生成される()
        {
            //Arrange
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var title = new TodoTitle("タイトル");
            var description = new TodoDescription("詳細");
            var operationDateTime = DateTime.Now;

            //Act
            var todo = Todo.CreateNew(
                title: title,
                description: description,
                ownerId: userId);

            //Assert
            Assert.That(todo.Title, Is.EqualTo(title));
            Assert.That(todo.Description, Is.EqualTo(description));
            Assert.That(todo.OwnerId, Is.EqualTo(userId));
            Assert.That(todo.CreatedDateTime, Is.InRange(operationDateTime, operationDateTime.AddSeconds(10)));
            Assert.That(todo.UpdatedDateTime, Is.InRange(operationDateTime, operationDateTime.AddSeconds(10)));
            Assert.That(todo.Status, Is.EqualTo(TodoStatus.InCompleted));
            Assert.That(todo.IsDeleted, Is.False);
            Assert.That(todo.DeletedDateTime, Is.Null);


        }

        [Test]
        public void リポジトリからTODOを作成するとインスタンスが生成される()
        {
            // Arrange
            var todoId = TodoId.Generate();
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var title = new TodoTitle("タイトル");
            var description = new TodoDescription("詳細");

            var createdDateTime = DateTime.Now;
            var updatedDateTime = DateTime.Now.AddDays(1);

            // Act
            var todo = Todo.CreateFromRepository(
                id: todoId,
                title: title,
                description: description,
                ownerId: userId,
                createdDateTime: createdDateTime,
                updatedDateTime: updatedDateTime,
                status: TodoStatus.Completed,
                isDeleted: false,
                deletedDateTime: null);

            // Assert
            Assert.That(todo.Title, Is.EqualTo(title));
            Assert.That(todo.Description, Is.EqualTo(description));
            Assert.That(todo.OwnerId, Is.EqualTo(userId));
            Assert.That(todo.CreatedDateTime, Is.EqualTo(createdDateTime));
            Assert.That(todo.UpdatedDateTime, Is.EqualTo(updatedDateTime));
            Assert.That(todo.Status, Is.EqualTo(TodoStatus.Completed));
            Assert.That(todo.IsDeleted, Is.False);
            Assert.That(todo.DeletedDateTime, Is.Null);
        }

        [Test]
        public void 引数にステータスを渡すとステータスが更新される()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                status: TodoStatus.InCompleted,
                isDeleted: false
                );

            //Act
            todo.UpdateStatus(TodoStatus.Completed);

            //Assert
            Assert.That(todo.Status, Is.EqualTo(TodoStatus.Completed));
        }

        [Test]
        public void 削除済のTODOのステータスを更新すると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                isDeleted: true,
                deletedDateTime: DateTime.Now);

            //Act
            //Assert
            Assert.That(
                () => todo.UpdateStatus(TodoStatus.Completed),
                Throws.TypeOf<DomainException>());
        }

        [Test]
        public void TODOを削除すると削除フラグが立ち削除した日付が入る()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                isDeleted: false,
                deletedDateTime: null);

            //Act
            todo.Delete();

            //Assert
            Assert.That(todo.IsDeleted, Is.True);
            Assert.That(todo.DeletedDateTime,
                        Is.InRange(DateTime.Now.AddSeconds(-10),
                                   DateTime.Now.AddSeconds(10))
                        );
        }

        [Test]
        public void 引数にタイトルと詳細を渡して編集する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                title: "タイトル",
                description: "説明文");
            var newTitle = new TodoTitle("新しいタイトル");
            var newDescription = new TodoDescription("新しい説明文");

            //Act
            todo.Edit(newTitle, newDescription);

            //Assert
            Assert.That(todo.Title, Is.EqualTo(newTitle));
            Assert.That(todo.Description, Is.EqualTo(newDescription));
        }

        [Test]
        public void 削除済のTODOを編集しようとすると例外が発生する()
        {
            //Arrange
            var todo = TodoGenerator.Generate(
                title: "タイトル",
                description: "説明文",
                isDeleted: true);
            var newTitle = new TodoTitle("新しいタイトル");
            var newDescription = new TodoDescription("新しい説明文");

            //Act
            //Assert
            Assert.That(
                () => todo.Edit(newTitle, newDescription),
                Throws.TypeOf<DomainException>());


        }


    }
}
