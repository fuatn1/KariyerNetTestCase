using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Core.Abstract
{
    public interface IUserInfoModel
    {
        long? UpdateUserInfo { get; set; }
        long? CreateUserInfo { get; set; }
        long? DeleteUserInfo { get; set; }
    }
}
