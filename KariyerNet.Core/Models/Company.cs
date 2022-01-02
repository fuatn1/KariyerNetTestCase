using KariyerNet.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Core.Models
{
    public class Company : IStatusModel, ITimeInfoModel, IUserInfoModel
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public DateTime DeleteDate { get ; set ; }
        public long? UpdateUserInfo { get ; set ; }
        public long? CreateUserInfo { get ; set ; }
        public long? DeleteUserInfo { get ; set ; }
        public int MaxJobAdvertisementCount { get; set; }
    }
}
