using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Todos;

namespace TodoManagementSystem.Infrastructure.DataModels.Todos
{
    public sealed class TodoDataModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: TodoTitle.MaxTodoTitleLength)]
        public string Title { get; set; }

        [StringLength(maximumLength: TodoDescription.MaxTodoDescriptionLength)]
        public string? Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDateTime { get; set; }

        [Required]
        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedDateTime { get; set; }
    }
}
