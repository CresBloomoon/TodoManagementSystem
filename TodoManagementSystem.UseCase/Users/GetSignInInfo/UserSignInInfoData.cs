using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Users.GetSignInInfo
{
    public sealed class UserSignInInfoData
    {
        public string Id { get; }
        public string Name { get; }
        public string Nickname { get; }

        public UserSignInInfoData(
            string id,
            string name,
            string nickname)
        {
            Id = id;
            Name = name;
            Nickname = nickname;
        }
    }
}
