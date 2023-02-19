using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Users
{
    public sealed class UserId : SingleValueObject<string>
    {
        public UserId(string value)
            : base(value)
        {
            if (!Guid.TryParseExact(value, "D", out _))
            {
                throw new DomainException("ユーザIDの形式が不正です。");
            }
        }
    }
}
