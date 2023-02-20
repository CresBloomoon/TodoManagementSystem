using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementSystem.Domain.Models.Users
{
    public enum UserStatus
    {
        /// <summary>
        /// 退会
        /// </summary>
        Withdrawn = -1,

        /// <summary>
        /// 仮登録
        /// </summary>
        TempRegistration = 10,

        /// <summary>
        /// 有効
        /// </summary>
        Enable = 20,
    }
}
