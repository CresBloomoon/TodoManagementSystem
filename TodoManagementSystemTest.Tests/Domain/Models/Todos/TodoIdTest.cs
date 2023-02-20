using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Todos;

namespace TodoManagementSystemTest.Tests.Domain.Models.Todos
{
    internal sealed class TodoIdTest
    {
        [Test]
        public void 引数に16桁の半角英数字を渡すとインスタンスが生成される()
        {
            //Arrange
            var value = Guid.NewGuid().ToString("N")[..16];

            //Act
            var todoId = new TodoId(value);

            //Assert
            Assert.That(todoId.Value, Is.EqualTo(value));
        }

        [Test]
        public void 引数に16桁以外の半角英数字を渡すと例外が発生する()
        {
            //Arrange
            var underValue = Guid.NewGuid().ToString("N")[..15];
            var overValue = Guid.NewGuid().ToString("N")[..17];

            //Act
            //Assert
            Assert.That(
                () => new TodoId(underValue),
                Throws.TypeOf<DomainException>());
            Assert.That(
                () => new TodoId(overValue),
                Throws.TypeOf<DomainException>());
        }
    }
}
