using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TodoManagementSystem.Domain.Models.Users.Specifications;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Users.TempRegister
{
    public sealed class UserTempRegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserTempRegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserTempRegisterResult> ExecuteAsync(UserTempRegisterCommand command)
        {
            using var ts = new TransactionScope();

            var user = User.CreateNew(
                id: new UserId(command.UserSession.Id),
                name: new Username(command.Name),
                email: new UserEmailAddress(command.Email),
                nickname: new UserNickname(command.Nickname));

            var spec = new UserDuplicationSpecification(_userRepository);
            if (await spec.IsSatisfiedByAsync(user))
            {
                throw new UseCaseException("指定されたユーザーは既に存在しています。");
            }

            await _userRepository.SaveAsync(user);

            ts.Complete();

            return new UserTempRegisterResult(user.Id.Value);
        }
    }
}
