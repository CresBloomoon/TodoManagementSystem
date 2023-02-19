using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Todos
{
    public class TodoDescription : SingleValueObject<string>
    {
        public const int MaxTodoDescriptionLength = 300;

        public TodoDescription(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MaxTodoDescriptionLength)
            {
                throw new DomainException(
                    $"詳細は1～{MaxTodoDescriptionLength}文字以内で設定してください。");
            }
        }
    }
}
