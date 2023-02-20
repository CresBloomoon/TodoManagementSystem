using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Domain.Models.Users.Specifications;
using TodoManagementSystem.Infrastructure.Users;
using TodoManagementSystemTest.Tests.Helpers;
using TodoManagementSystemTest.Tests.Shared;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users.Specifications
{
    internal class UserDuplicationSpecificationTest : UseDbContextTestBase
    {
        private readonly IUserRepository _userRepository;

        public UserDuplicationSpecificationTest()
        {
            _userRepository = new UserRepository(TestDbContext);
        }

        [Test]
        public async Task 既存のユーザーが存在するかどうか判定する()
        {
            //Arrange
            var user1 = UserGenerator.Generate(name: "user1");
            var user2 = UserGenerator.Generate(name: "user2");
            await _userRepository.SaveAsync(user1);
            await _userRepository.SaveAsync(user2);
            var spec = new UserDuplicationSpecification(_userRepository);

            //Act
            var exists1 = await spec.IsSatisfiedByAsync(user1);
            var exists2 = await spec.IsSatisfiedByAsync(user2);

            //Assert
            Assert.That(exists1, Is.True);
            Assert.That(exists2, Is.True);
        }
    }
}
