using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Users.GetSignInInfo
{
    public interface IUserGetSignInInfoQueryService
    {
        Task<UserGetSignInInfoResult> ExecuteAsync(UserGetSignInInfoCommand command);
    }
}
