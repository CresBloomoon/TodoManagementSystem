using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Users.TempRegister
{
    public sealed class UserTempRegisterCommand
    {
        public UserSession UserSession { get; }
        public string Name { get; }
        public string Email { get; }
        public string Nickname { get; }

        public UserTempRegisterCommand(
            UserSession userSession,
            string name,
            string email,
            string nickname)
        {
            UserSession = userSession;
            Name = name;
            Email = email;
            Nickname = nickname;
        }
    }
}
