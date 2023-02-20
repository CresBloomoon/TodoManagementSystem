using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using TodoManagementSystem.Infrastructure.Todos;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;
using NUnit.Framework;

namespace TodoManagementSystemTest.Tests.Infrastructure.Todos
{
    public class TodoRepositoryTest : UseDbContextTestBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoRepositoryTest()
        {
            _todoRepository = new TodoRepository(TestDbContext);
        }

        [Test]
        public async Task 引数にTODOモデルを渡すとDBに保存される()
        {
            //Arrange
            var todo = TodoGenerator.Generate();

            //Act
            await _todoRepository.SaveAsync(todo);

            //Assert
            var todoDataModel = await TestDbContext.Todos
                .FindAsync(todo.Id.Value);
            Assert.That(todoDataModel, Is.Not.Null);
            Assert.That(todoDataModel?.Id, Is.EqualTo(todo.Id.Value));
            Assert.That(todoDataModel?.Title, Is.EqualTo(todo.Title.Value));
            Assert.That(todoDataModel?.Description, Is.EqualTo(todo.Description?.Value));
            Assert.That(todoDataModel?.OwnerId, Is.EqualTo(todo.OwnerId.Value));
            Assert.That(todoDataModel?.Status, Is.EqualTo((int)todo.Status));
            Assert.That(todoDataModel?.CreatedDateTime, Is.EqualTo(todo.CreatedDateTime));
            Assert.That(todoDataModel?.UpdatedDateTime, Is.EqualTo(todo.UpdatedDateTime));
            Assert.That(todoDataModel?.IsDeleted, Is.EqualTo(todo.IsDeleted));
            Assert.That(todoDataModel?.DeletedDateTime, Is.EqualTo(todo.DeletedDateTime));
        }

        [Test]
        public async Task 引数にTODOのIDを渡すとDBからTODOを生成する()
        {
            //Arrange
            var todo = TodoGenerator.Generate();
            await _todoRepository.SaveAsync(todo);

            //Act
            var foundTodo = await _todoRepository.FindAsync(todo.Id);

            //Assert
            Assert.That(foundTodo, Is.Not.Null);
            Assert.That(foundTodo?.Id, Is.EqualTo(todo.Id));
            Assert.That(foundTodo?.Title, Is.EqualTo(todo.Title));
            Assert.That(foundTodo?.Description, Is.EqualTo(todo.Description));
            Assert.That(foundTodo?.OwnerId, Is.EqualTo(todo.OwnerId));
            Assert.That(foundTodo?.Status, Is.EqualTo(todo.Status));
            Assert.That(foundTodo?.CreatedDateTime, Is.EqualTo(todo.CreatedDateTime));
            Assert.That(foundTodo?.UpdatedDateTime, Is.EqualTo(todo.UpdatedDateTime));
            Assert.That(foundTodo?.IsDeleted, Is.EqualTo(todo.IsDeleted));
            Assert.That(foundTodo?.DeletedDateTime, Is.EqualTo(todo.DeletedDateTime));
        }

        [Test]
        public async Task 引数に存在しないTODOのIDを渡すとnullが返る()
        {
            //Arrange
            var todo = TodoGenerator.Generate();

            //Act
            var foundTodo = await _todoRepository.FindAsync(todo.Id);

            //Assert
            Assert.That(foundTodo, Is.Null);
        }
    }
}
