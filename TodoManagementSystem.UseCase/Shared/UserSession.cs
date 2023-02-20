using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Shared
{
    public sealed class UserSession
    {
        public string Id { get; }
        public UserSession(string id)
        {
            Id = id;
        }
    }
}
