using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;

namespace TodoManagementSystem.Domain.Models.Todos
{
    public sealed class TodoId : SingleValueObject<string>
    {
        private const int TodoIdLength = 16;

        public TodoId(string value)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length != TodoIdLength)
            {
                throw new DomainException(
                    "TODO IDの形式が不正です。");
            }
        }

        public static TodoId Generate()
        {
            return new TodoId(
                Guid.NewGuid()
                    .ToString("N")[..TodoIdLength]);
        }
    }
}
