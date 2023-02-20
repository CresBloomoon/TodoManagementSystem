using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.UseCase.Users.GetSignInInfo
{
    public sealed class UserGetSignInInfoResult
    {
        public UserSignInInfoData? SignInInfo { get; }

        public UserGetSignInInfoResult(UserSignInInfoData? signInInfo)
        {
            SignInInfo = signInInfo;
        }
    }
}
