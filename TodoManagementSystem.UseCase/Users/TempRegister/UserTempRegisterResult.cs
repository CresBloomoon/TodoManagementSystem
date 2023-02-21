using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Users.TempRegister
{
    public sealed class UserTempRegisterResult
    {
        public string Id { get; }

        public UserTempRegisterResult(string id)
        {
            Id = id;
        }
    }
}
