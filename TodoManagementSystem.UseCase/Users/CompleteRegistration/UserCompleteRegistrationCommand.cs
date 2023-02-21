using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Users.CompleteRegistration
{
    public sealed class UserCompleteRegistrationCommand
    {
        public UserSession UserSession { get; }

        public UserCompleteRegistrationCommand(UserSession userSession)
        {
            UserSession = userSession;
        }
    }
}
