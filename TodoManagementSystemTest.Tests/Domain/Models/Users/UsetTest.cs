using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystemTest.Tests.Helpers;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users
{
    internal sealed class UsetTest
    {
        [Test]
        public void 新しくユーザーを作成すると一般ユーザーの仮登録状態でインスタンスが生成される()
        {
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var userName = new Username("username");
            var userEmail = new UserEmailAddress("user@text.com");
            var nickname = new UserNickname("ニックネーム");

            var user = User.CreateNew(
                id: userId,
                name: userName,
                email: userEmail,
                nickname: nickname);

            Assert.That(user.Id, Is.EqualTo(userId));
            Assert.That(user.Name, Is.EqualTo(userName));
            Assert.That(user.Email, Is.EqualTo(userEmail));
            Assert.That(user.Profile.Id, Is.EqualTo(userId));
            Assert.That(user.Profile.Nickname, Is.EqualTo(nickname));
            Assert.That(user.Status, Is.EqualTo(UserStatus.TempRegistration));
        }

        [Test]
        public void リポジトリからユーザーを作成すると引数の値でインスタンスが生成される()
        {
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var userName = new Username("username");
            var userEmail = new UserEmailAddress("user@text.com");
            var nickname = new UserNickname("ニックネーム");
            const UserStatus userStatus = UserStatus.Enable;
            var now = DateTime.Now;

            var user = User.CreateFromRepository(
                id: userId,
                name: userName,
                email: userEmail,
                nickname: nickname,
                status: userStatus,
                registeredDateTime: now,
                updatedDateTime: now);

            Assert.That(user.Id, Is.EqualTo(userId));
            Assert.That(user.Name, Is.EqualTo(userName));
            Assert.That(user.Email, Is.EqualTo(userEmail));
            Assert.That(user.Profile.Id, Is.EqualTo(userId));
            Assert.That(user.Profile.Nickname, Is.EqualTo(nickname));
            Assert.That(user.Status, Is.EqualTo(userStatus));
            Assert.That(user.RegisteredDateTime, Is.EqualTo(now));
            Assert.That(user.UpdatedDateTime, Is.EqualTo(now));
        }

        [Test]
        public void 引数にステータスを渡すとユーザーのステータスが変更される()
        {
            var user = UserGenerator.Generate(status: UserStatus.TempRegistration);

            user.ChangeStatus(UserStatus.Enable);

            Assert.That(user.Status, Is.EqualTo(UserStatus.Enable));
        }

        [Test]
        public void 削除されたユーザーのステータスを変更しようとすると例外が発生する()
        {
            var user = UserGenerator.Generate(status: UserStatus.Withdrawn);

            Assert.That(
                () => user.ChangeStatus(UserStatus.Enable),
                Throws.TypeOf<DomainException>());
        }
    }
}
