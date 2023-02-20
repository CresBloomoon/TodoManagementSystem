using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;
using NUnit.Framework;
using TodoManagementSystem.Domain.Models.Shared;

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

        [Test]
        public void 引数に301文字以上の文字列を渡すと例外が発生する()
        {
            //Arrange
            const string value =
                "この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです。文字の";

            //Act
            //Assert
            Assert.That(
                () => new TodoDescription(value),
                Throws.TypeOf<DomainException>());
        }
    }
}
