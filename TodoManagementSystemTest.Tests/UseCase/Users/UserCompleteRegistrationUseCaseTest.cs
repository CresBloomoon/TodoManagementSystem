using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Infrastructure.Users;
using TodoManagementSystem.UseCase.Shared;
using TodoManagementSystem.UseCase.Users.CompleteRegistration;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.UseCase.Users
{
    internal sealed class UserCompleteRegistrationUseCaseTest : UseDbContextTestBase
    {
        private readonly UserCompleteRegistrationUseCase _userCompleteRegistrationUseCase;
        private readonly IUserRepository _userRepository;

        public UserCompleteRegistrationUseCaseTest()
        {
            _userRepository = new UserRepository(TestDbContext);
            _userCompleteRegistrationUseCase = new UserCompleteRegistrationUseCase(_userRepository);
        }

        [Test]
        public async Task 仮登録ユーザーの登録を完了して有効にする()
        {
            //Arrange
            var user = UserGenerator.Generate(status: UserStatus.TempRegistration);
            await _userRepository.SaveAsync(user);

            //Act
            var command = new UserCompleteRegistrationCommand(
                userSession: new UserSession(user.Id.Value));
            await _userCompleteRegistrationUseCase.ExecuteAsync(command);

            //Assert
            var foundUser = await _userRepository.FindAsync(user.Id);
            Assert.That(foundUser?.Status, Is.EqualTo(UserStatus.Enable));
        }
    }
}
