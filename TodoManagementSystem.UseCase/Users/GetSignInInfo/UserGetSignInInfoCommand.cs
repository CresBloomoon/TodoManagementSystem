using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Users.GetSignInInfo
{
    public sealed class UserGetSignInInfoCommand
    {
        public UserSession UserSession { get; }

        public UserGetSignInInfoCommand(UserSession userSession)
        {
            UserSession = userSession;
        }
    }
}
