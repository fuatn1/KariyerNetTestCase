﻿using KariyerNet.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Core.Models
{
    public class CompanyUser : IStatusModel, ITimeInfoModel, IUserInfoModel
    {
        public long CompanyUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public DateTime DeleteDate { get ; set ; }
        public long? UpdateUserInfo { get ; set ; }
        public long? CreateUserInfo { get ; set ; }
        public long? DeleteUserInfo { get ; set ; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
