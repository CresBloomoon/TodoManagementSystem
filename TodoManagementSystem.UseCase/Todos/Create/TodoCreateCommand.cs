using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Todos.Create
{
    public sealed class TodoCreateCommand
    {
        public UserSession UserSession { get; }
        public string Title { get; }
        public string? Description { get; }

        public TodoCreateCommand(
            UserSession userSession,
            string title,
            string? description)
        {
            UserSession = userSession;
            Title = title;
            Description = description;
        }
    }
}
