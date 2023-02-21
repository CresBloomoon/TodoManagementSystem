using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Delete
{
    public sealed class TodoDeleteCommand
    {
        public UserSession UserSession { get; }
        public string Id { get; }

        public TodoDeleteCommand(UserSession userSession, string id)
        {
            UserSession = userSession;
            Id = id;
        }
    }
}
