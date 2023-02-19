using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystem.Domain.Models.Todos
{
    public sealed class Todo
    {
        public TodoId Id { get; }
        public TodoTitle Title { get; private set; }
        public TodoDescription? Description { get; private set; }
        public UserId OwnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public TodoStatus Status { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedDateTime { get; private set; }

        private Todo(TodoId id,
                     TodoTitle title,
                     TodoDescription? description,
                     UserId ownerId,
                     DateTime createdDateTime,
                     DateTime updatedDateTime,
                     TodoStatus status,
                     bool isDeleted,
                     DateTime? deletedDateTime
                     ){
            Id = id;
            Title = title;
            Description = description;
            OwnerId = ownerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Status = status;
            IsDeleted = isDeleted;
            DeletedDateTime = deletedDateTime;
        }

    }
}
