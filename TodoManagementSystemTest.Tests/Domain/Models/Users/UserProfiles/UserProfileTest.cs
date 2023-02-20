using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users.UserProfiles
{
    internal sealed class UserProfileTest
    {
        [Test]
        public void 新しくユーザープロフィールを作成すると引数の値でインスタンスが生成される()
        {
            //Arrange
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var nickname = new UserNickname("ニックネーム");

            //Act
            var userProfile = UserProfile.CreateNew(
                id: userId,
                nickname: nickname);

            //Assert
            Assert.That(userProfile.Id, Is.EqualTo(userId));
            Assert.That(userProfile.Nickname, Is.EqualTo(nickname));
        }

        [Test]
        public void リポジトリからユーザープロフィールを作成すると引数の値でインスタンスが生成される()
        {
            //Arrange
            var userId = new UserId(Guid.NewGuid().ToString("D"));
            var nickname = new UserNickname("ニックネーム");

            //Act
            var userProfile = UserProfile.CreateFromRepository(
                id: userId,
                nickname: nickname);

            //Assert
            Assert.That(userProfile.Id, Is.EqualTo(userId));
            Assert.That(userProfile.Nickname, Is.EqualTo(nickname));
        }
    }
}
