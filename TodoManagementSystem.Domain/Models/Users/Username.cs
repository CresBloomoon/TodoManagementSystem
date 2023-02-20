using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Users
{
    public sealed class Username : SingleValueObject<string>
    {
        public const int MaxUsernameLength = 30;

        public Username(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MaxUsernameLength ||
                !Regex.IsMatch(value, "^[a-zA-Z]+[a-zA-Z0-9_\\-]*$"))
            {
                throw new DomainException(
                    $"ユーザ名は1～{MaxUsernameLength}文字の半角英数字、ハイフン、アンダーバーで設定してください。");
            }
        }
    }
}
