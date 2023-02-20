using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users;

namespace TodoManagementSystem.Infrastructure.DataModels.Users
{
    public sealed class UserDataModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: Username.MaxUsernameLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegisteredDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDateTime { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
