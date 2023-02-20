using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Users.UserProfiles
{
    public sealed class UserProfile
    {
        public UserId Id { get; }
        public UserNickname Nickname { get; }

        private UserProfile(
            UserId id,
            UserNickname nickname )
        {
            Id = id;
            Nickname = nickname;
        }

        public static UserProfile CreateNew(
            UserId id,
            UserNickname nickname )
        {
            return new UserProfile(
                id: id ?? throw new DomainException("ユーザーIDを設定してください。"),
                nickname: nickname ?? throw new DomainException("ニックネームを設定してください。"));
        }

        public static UserProfile CreateFromRepository(
            UserId id,
            UserNickname nickname)
        {
            return new UserProfile(
                id: id,
                nickname: nickname);
        }


    }
}
