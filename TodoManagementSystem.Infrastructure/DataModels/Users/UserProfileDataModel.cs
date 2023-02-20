using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;

namespace TodoManagementSystem.Infrastructure.DataModels.Users
{
    public sealed class UserProfileDataModel
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(maximumLength: UserNickname.MaxNicknameLength)]
        public string Nickname { get; set; }
    }
}
