using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users
{
    internal sealed class UserEmailAddressTest
    {
        [Test]
        public void 引数にメールアドレス形式の文字列を渡すとインスタンスが生成される()
        {
            //Arrange
            const string emailValue =
                "test_test_test@example.com";

            //Act
            var email = new UserEmailAddress(emailValue);

            //Assert
            Assert.That(email.Value, Is.EqualTo(emailValue));
        }

        [Test]
        public void 引数にメールアドレス形式以外の文字列を渡すと例外が発生する()
        {
            //Arrange
            const string emailValue =
                "invalid email address";

            //Act
            //Assert
            Assert.That(
                () => new UserEmailAddress(emailValue),
                Throws.TypeOf<DomainException>());
        }
    }
}
