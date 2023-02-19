using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.Domain.Models.Shared
{
    public class SingleValueObject<T> : ValueObject
    {
        public T Value 
        { get; }

        protected SingleValueObject(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value),
                                                             "値を設定してください");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (Value is null)
            {
                throw new ArgumentNullException(nameof(Value),
                                                "値を設定してください");
            }

            yield return Value;
        }
    }
}
