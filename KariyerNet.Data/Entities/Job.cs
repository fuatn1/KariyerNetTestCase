using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Entities
{
    public class Job 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public bool IsActive { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime ExpirationTime { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public DateTime DeleteDate { get ; set ; }
        public long? UpdateUserInfo { get ; set ; }
        public long? CreateUserInfo { get ; set ; }
        public long? DeleteUserInfo { get ; set ; }
        public int Score { get; set; }
        public virtual List<Offer> Offers { get; set; }
    }
}
