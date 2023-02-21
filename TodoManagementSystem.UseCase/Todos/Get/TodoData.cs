using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Todos.Get
{
    public sealed class TodoData
    {
        public string Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public int Status { get; }
        public string StatusName { get; }
        public DateTime CreatedDateTime { get; }

        public TodoData(
            string id,
            string title,
            string? description,
            int status,
            string statusName,
            DateTime createdDateTime)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            StatusName = statusName;
            CreatedDateTime = createdDateTime;
        }
    }
}
