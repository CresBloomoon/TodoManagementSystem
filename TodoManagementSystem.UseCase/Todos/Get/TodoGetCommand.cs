using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Get
{
    public sealed class TodoGetCommand
    {
        public UserSession UserSession { get; }
        public string Id { get; }

        public TodoGetCommand(UserSession userSession, string id)
        {
            UserSession = userSession;
            Id = id;
        }
    }
}
