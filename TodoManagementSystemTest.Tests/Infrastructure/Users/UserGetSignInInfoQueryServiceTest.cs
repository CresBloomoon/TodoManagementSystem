using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Infrastructure.Users;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Users.GetSignInInfo;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.Infrastructure.Users
{
    internal sealed class UserGetSignInInfoQueryServiceTest : UseDbContextTestBase
    {
        private readonly IUserGetSignInInfoQueryService _userGetSignInInfoQueryService;
        private readonly IUserRepository _userRepository;

        public UserGetSignInInfoQueryServiceTest()
        {
            _userGetSignInInfoQueryService = new UserGetSignInInfoQueryService(TestDbContext);
            _userRepository = new UserRepository(TestDbContext);
        }

        [Test]
        public async Task 引数にセッション情報から取得したIDを渡すとサインイン情報を返す()
        {
            //Arrange
            var user = UserGenerator.Generate();
            await _userRepository.SaveAsync(user);

            //Act
            var command = new UserGetSignInInfoCommand(
                userSession: new UserSession(user.Id.Value));
            var result = await _userGetSignInInfoQueryService.ExecuteAsync(command);

            //Assert
            Assert.That(result.SignInInfo, Is.Not.Null);
            Assert.That(result.SignInInfo?.Id, Is.EqualTo(user.Id.Value));
            Assert.That(result.SignInInfo?.Name, Is.EqualTo(user.Name.Value));
            Assert.That(result.SignInInfo?.Nickname, Is.EqualTo(user.Profile.Nickname.Value));
        }

        [Test]
        public async Task 引数に不正なセッション情報が渡された場合nullを返す()
        {
            //Arrange
            var command = new UserGetSignInInfoCommand(
                userSession: new UserSession(Guid.NewGuid().ToString("D")));

            //Act
            var result = await _userGetSignInInfoQueryService.ExecuteAsync(command);

            //Arrange
            Assert.That(result.SignInInfo, Is.Null);
        }
    }
}
