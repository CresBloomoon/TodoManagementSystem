using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.Domain.Models.Users
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
        Task<User?> FindAsync(UserId id);
        Task<bool> ExistsById(UserId id);
        Task<bool> ExistsByName(Username name);
        Task<bool> ExistsByEmail(UserEmailAddress email);
    }
}
