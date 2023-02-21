using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.UpdateStatus
{
    public sealed class TodoUpdateStatusCommand
    {
        public UserSession UserSession { get; }
        public string Id { get; }
        public int Status { get; }

        public TodoUpdateStatusCommand(
            UserSession userSession,
            string id,
            int status)
        {
            UserSession = userSession;
            Id = id;
            Status = status;
        }
    }
}
