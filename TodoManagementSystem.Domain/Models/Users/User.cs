using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;

namespace TodoManagementSystem.Domain.Models.Users
{
    public sealed class User
    {
        public UserId Id { get; }
        public Username Name { get; }
        public UserEmailAddress Email { get; }
        public UserProfile Profile { get; }
        public DateTime RegisteredDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public UserStatus Status { get; private set; }

        private User(
            UserId id,
            Username name,
            UserEmailAddress email,
            UserProfile profile,
            DateTime registeredDateTime,
            DateTime updatedDateTime,
            UserStatus status)
        {
            Id = id;
            Name = name;
            Email = email;
            Profile = profile;
            RegisteredDateTime = registeredDateTime;
            UpdatedDateTime = updatedDateTime;
            Status = status;
        }

        public static User CreateNew(
            UserId id,
            Username name,
            UserEmailAddress email,
            UserNickname nickname)
        {
            var operationDateTime = DateTime.Now;

            return new User(
                id: id ?? throw new DomainException("ユーザーIDを設定してください。"),
                name: name ?? throw new DomainException("ユーザー名を設定してください。"),
                email: email ?? throw new DomainException("メールアドレスを設定してください。"),
                profile: UserProfile.CreateNew(
                    id: id,
                    nickname: nickname),
                registeredDateTime: operationDateTime,
                updatedDateTime: operationDateTime,
                status: UserStatus.TempRegistration);
        }

        public static User CreateFromRepository(
            UserId id,
            Username name,
            UserEmailAddress email,
            UserNickname nickname,
            DateTime registeredDateTime,
            DateTime updatedDateTime,
            UserStatus status)
        {
            return new User(
                id: id,
                name: name,
                email: email,
                profile: UserProfile.CreateFromRepository(
                    id: id,
                    nickname: nickname),
                registeredDateTime: registeredDateTime,
                updatedDateTime: updatedDateTime,
                status: status);
        }

        public void ChangeStatus(UserStatus status)
        {
            if (Status == status) return;
            if (Status == UserStatus.Withdrawn)
            {
                throw new DomainException(
                    "退会したユーザーのステータスは変更できません。");
            }

            Status = status;
        }
    }
}
