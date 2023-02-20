using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Infrastructure.DataModels;
using TodoManagementSystem.UseCase.Users.GetSignInInfo;

namespace TodoManagementSystem.Infrastructure.Users
{
    public sealed class UserGetSignInInfoQueryService : IUserGetSignInInfoQueryService
    {
        private readonly AppDbContext _dbContext;

        public UserGetSignInInfoQueryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserGetSignInInfoResult> ExecuteAsync(UserGetSignInInfoCommand command)
        {
            var userDataModel = await _dbContext.Users
                .FindAsync(command.UserSession.Id);

            if (userDataModel is null) return new UserGetSignInInfoResult(null);

            var userProfileDataModel = await _dbContext.UserProfiles
                .FindAsync(command.UserSession.Id);

            if (userProfileDataModel is null) return new UserGetSignInInfoResult(null);

            return new UserGetSignInInfoResult(
                signInInfo: new UserSignInInfoData(
                    id: userDataModel.Id,
                    name: userDataModel.Name,
                    nickname: userProfileDataModel.Nickname));
        }
    }
}
