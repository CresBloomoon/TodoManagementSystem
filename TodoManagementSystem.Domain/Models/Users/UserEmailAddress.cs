using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Users
{
    public sealed class UserEmailAddress : SingleValueObject<string>
    {
        public UserEmailAddress(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !CheckEmailFormat(value))
            {
                throw new DomainException(
                    "メールアドレスの形式が不正です。");
            }
        }

        private static bool CheckEmailFormat(string email)
        {
            try
            {
                _ = new MailAddress(email);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
    }
}
