using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;

namespace TodoManagementSystemTest.Tests.Helpers
{
    internal sealed class UserGenerator
    {
        public static User Generate(
            string? id = null,
            string? name = null,
            string? email = null,
            string? nickname = null,
            DateTime? registeredDateTime = null,
            DateTime? updatedDateTime = null,
            UserStatus status = UserStatus.Enable)
        {
            return User.CreateFromRepository(
                id: id is null ? new UserId(Guid.NewGuid().ToString("D")) : new UserId(id),
                name: name is null ? new Username("username") : new Username(name),
                email: email is null ? new UserEmailAddress("user@test.com") : new UserEmailAddress(email),
                nickname: nickname is null ? new UserNickname("ニックネーム") : new UserNickname(nickname),
                registeredDateTime: registeredDateTime ?? DateTime.Now,
                updatedDateTime: updatedDateTime ?? DateTime.Now,
                status: status);

        }
    }
}
