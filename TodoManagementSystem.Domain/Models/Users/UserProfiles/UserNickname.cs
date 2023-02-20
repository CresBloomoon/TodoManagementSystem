using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Users.UserProfiles
{
    public sealed class UserNickname : SingleValueObject<string>
    {
        public const int MaxNicknameLength = 30;

        public UserNickname(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MaxNicknameLength)
            {
                throw new DomainException(
                    $"ニックネームは1～{MaxNicknameLength}文字以内で設定してください。");
            }
        }
    }
}
