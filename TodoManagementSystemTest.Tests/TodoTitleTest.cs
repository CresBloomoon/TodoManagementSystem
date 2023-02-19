using NuGet.Frameworks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Todos;

namespace TodoManagementSystemTest.Tests
{
    public class Tests
    {
        [Test]
        public void ������50�����ȉ��̕������n���ƃC���X�^���X�����������()
        {
            //Arrange
            const string titleValue = "TodoTitle";

            //Act
            var title = new TodoTitle(titleValue);

            //Assert
            Assert.That(title.Value, Is.EqualTo(titleValue));
        }

        [Test]
        public void ������51�����ȏ�̕������n���Ɨ�O����������()
        {
            //Arrange
            const string titleValue = "abcdefghijklmnopqrstuvwxyz1234567890123456789012345";

            Assert.That(
                () => new TodoTitle(titleValue),
                Throws.TypeOf<DomainException>());
        }
    }
}