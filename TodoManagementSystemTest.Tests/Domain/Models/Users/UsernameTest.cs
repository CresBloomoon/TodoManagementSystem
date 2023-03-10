using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users
{
    internal sealed class UsernameTest
    {
        [Test]
        public void 引数に30文字以下の半角英数字を渡すとインスタンスが生成される()
        {
            const string value = "user-name_1";
            var username = new Username(value);

            Assert.That(username.Value, Is.EqualTo(value));
        }

        [TestCase("ユーザー名", TestName = "引数に全角を含む文字列を渡すと例外が発生する")]
        [TestCase("Lorem_ipsum_dolor_sit_amet_dui.", TestName = "引数に31文字以上の文字列を渡すと例外が発生する")]
        [Test]
        public void 引数に不正な文字列を渡すと例外が発生する(string username)
        {
            Assert.That(
                () => new Username(username),
                Throws.TypeOf<DomainException>());
        }
    }
}
