using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.Domain.Models.Shared
{
    public class DomainException : Exception
    {
        public int? StatusCode { get; }

        public DomainException(string? message, int? statusCode = null)
            : base(message)
        {
            StatusCode= statusCode;
        }
    }
}
