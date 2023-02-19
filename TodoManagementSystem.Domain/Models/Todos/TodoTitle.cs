using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Todos
{
    public sealed class TodoTitle : SingleValueObject<string>
    {
        public const int MaxTodoTitleLength = 50;

        public TodoTitle(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MaxTodoTitleLength)
            {
                throw new DomainException(
                    $"タイトルは 1 ～ {MaxTodoTitleLength}文字以内で設定してください。");
            }
        }
    }
}
