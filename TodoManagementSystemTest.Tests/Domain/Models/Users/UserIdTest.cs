using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users
{
    internal sealed class UserIdTest
    {
        [Test]
        public void 引数にハイフン付きGUIDを渡すとユーザーIDインスタンスが生成される()
        {
            var guid = Guid.NewGuid().ToString("D");

            var userId = new UserId(guid);

            Assert.That(userId.Value, Is.EqualTo(guid));
        }

        [Test]
        public void 引数にハイフン付きGUID以外の文字列を渡すと例外が発生する()
        {
            var guid = Guid.NewGuid().ToString("N");

            Assert.That(
                () => new UserId(guid),
                Throws.TypeOf<DomainException>());
        }
    }
}
