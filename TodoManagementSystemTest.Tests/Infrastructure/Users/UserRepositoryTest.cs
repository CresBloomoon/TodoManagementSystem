using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Infrastructure.Users;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.Infrastructure.Users
{
    internal sealed class UserRepositoryTest : UseDbContextTestBase
    {
        private readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            _userRepository = new UserRepository(TestDbContext);
        }

        [Test]
        public async Task 引数にユーザーモデルを渡すとDBに保存される()
        {
            //Arrange
            var user = UserGenerator.Generate();

            //Act
            await _userRepository.SaveAsync(user);

            //Assert
            var userDataModel = await TestDbContext.Users
                .FindAsync(user.Id.Value);
            Assert.That(userDataModel, Is.Not.Null);
            Assert.That(userDataModel?.Id, Is.EqualTo(user.Id.Value));
            Assert.That(userDataModel?.Name, Is.EqualTo(user.Name.Value));
            Assert.That(userDataModel?.Email, Is.EqualTo(user.Email.Value));
            Assert.That(userDataModel?.Status, Is.EqualTo((int)user.Status));
            Assert.That(userDataModel?.RegisteredDateTime, Is.EqualTo(user.RegisteredDateTime));
            Assert.That(userDataModel?.UpdatedDateTime, Is.EqualTo(user.UpdatedDateTime));

            var userProfileDataModel = await TestDbContext.UserProfiles
                .FindAsync(user.Id.Value);
            Assert.That(userProfileDataModel, Is.Not.Null);
            Assert.That(userProfileDataModel?.UserId, Is.EqualTo(user.Id.Value));
            Assert.That(userProfileDataModel?.Nickname, Is.EqualTo(user.Profile.Nickname.Value));
        }

        [Test]
        public async Task 引数に既存ユーザモデルを更新して渡すとDBの情報が更新される()
        {
            //Arrange
            //まずは「ユーザがすでに存在している」状況を作る
            var user = UserGenerator.Generate(status: UserStatus.Enable);
            await _userRepository.SaveAsync(user);

            //Act
            //退会状態にして保存する
            user.ChangeStatus(UserStatus.Withdrawn);
            await _userRepository.SaveAsync(user);

            //Assert
            var foundUser = await _userRepository.FindAsync(user.Id);
            Assert.That(foundUser?.Status, Is.EqualTo(UserStatus.Withdrawn));

        }

        [Test]
        public async Task 引数にユーザーIDを渡すとDBの情報からユーザーモデルが作成されて返される()
        {
            //Arrange
            var user = UserGenerator.Generate();
            await _userRepository.SaveAsync(user);

            //Act
            var foundUser = await _userRepository.FindAsync(user.Id);

            //Assert
            Assert.That(foundUser, Is.Not.Null);
            Assert.That(foundUser?.Id, Is.EqualTo(user.Id));
            Assert.That(foundUser?.Name, Is.EqualTo(user.Name));
            Assert.That(foundUser?.Email, Is.EqualTo(user.Email));
            Assert.That(foundUser?.Profile.Nickname, Is.EqualTo(user.Profile.Nickname));
            Assert.That(foundUser?.RegisteredDateTime, Is.EqualTo(user.RegisteredDateTime));
            Assert.That(foundUser?.UpdatedDateTime, Is.EqualTo(user.UpdatedDateTime));
            Assert.That(foundUser?.Status, Is.EqualTo(user.Status));
        }

        [Test]
        public async Task 引数にユーザーIDを渡すと存在しているかどうか判定する()
        {
            //Arrange
            var existUser = UserGenerator.Generate(name: "ExistUser");
            await _userRepository.SaveAsync(existUser);

            var newUser = UserGenerator.Generate(name: "NewUser");

            //Act
            var exist = await _userRepository.ExistsById(existUser.Id);
            var exist2 = await _userRepository.ExistsById(newUser.Id);

            //Assert
            Assert.That(exist, Is.True);
            Assert.That(exist2, Is.False);
        }

        [Test]
        public async Task 引数にユーザー名を渡すと存在しているかどうか判定する()
        {
            //Arrange
            var existUser = UserGenerator.Generate(name: "ExistUser");
            await _userRepository.SaveAsync(existUser);

            var newUser = UserGenerator.Generate(name: "NewUser");

            //Act
            var exist = await _userRepository.ExistsByName(existUser.Name);
            var exist2 = await _userRepository.ExistsByName(newUser.Name);

            //Assert
            Assert.That(exist, Is.True);
            Assert.That(exist2, Is.False);
        }

        [Test]
        public async Task 引数にメールアドレスを渡すと存在しているかどうか判定する()
        {
            //Arrange
            var existUser = UserGenerator.Generate(
                name: "ExistUser",
                email: "exist_user@test.com");
            await _userRepository.SaveAsync(existUser);

            var newUser = UserGenerator.Generate(
                name: "NewUser",
                email: "new_user@test.com");

            //Act
            var exist = await _userRepository.ExistsByEmail(existUser.Email);
            var exist2 = await _userRepository.ExistsByEmail(newUser.Email);

            //Assert
            Assert.That(exist, Is.True);
            Assert.That(exist2, Is.False);
        }
    }
}
