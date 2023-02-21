using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Shared
{
    public sealed class UseCaseException : Exception
    {
        public int? StatusCode { get; }

        public UseCaseException(
            string? message,
            int? statusCode = null)
            : base(message)
        {
            StatusCode= statusCode;
        }
    }
}
