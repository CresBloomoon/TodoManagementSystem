using NuGet.Frameworks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Todos;

namespace TodoManagementSystemTest.Tests
{
    public class Tests
    {
        [Test]
        public void 引数に50文字以下の文字列を渡すとインスタンスが生成される()
        {
            //Arrange
            const string titleValue = "TodoTitle";

            //Act
            var title = new TodoTitle(titleValue);

            //Assert
            Assert.That(title.Value, Is.EqualTo(titleValue));
        }

        [Test]
        public void 引数に51文字以上の文字列を渡すと例外が発生する()
        {
            //Arrange
            const string titleValue = "abcdefghijklmnopqrstuvwxyz1234567890123456789012345";

            Assert.That(
                () => new TodoTitle(titleValue),
                Throws.TypeOf<DomainException>());
        }
    }
}