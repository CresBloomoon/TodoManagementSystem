using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using NUnit.Framework;

namespace TodoManagementSystemTest.Tests.Domain.Models.Todos
{
    internal sealed class TodoDescriptionTest
    {
        [Test]
        public void 引数に300文字以下の文字列を渡すとインスタンスが生成される()
        {
            //Arrange
            const string value = "テスト";

            //Act
            var description = new TodoDescription(value);

            //Assert
            Assert.That(description.Value, Is.EqualTo(value));
        }
    }
}
