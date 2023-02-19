using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Domain.Models.Users;

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

        }
    }
}
