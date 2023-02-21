using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TodoManagementSystem.Domain.Models.Users;
using TodoManagementSystem.UseCase.Shared;

namespace TodoManagementSystem.UseCase.Users.CompleteRegistration
{
    public sealed class UserCompleteRegistrationUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserCompleteRegistrationUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(UserCompleteRegistrationCommand command)
        {
            var ts = new TransactionScope();

            var user = await _userRepository.FindAsync(new UserId(command.UserSession.Id));

            if (user is null)
            {
                throw new UseCaseException("指定されたユーザーが見つかりません。");
            }

            user.ChangeStatus(UserStatus.Enable);

            await _userRepository.SaveAsync(user);

            ts.Complete();
        }
    }
}
