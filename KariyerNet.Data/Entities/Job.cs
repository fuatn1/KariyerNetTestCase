using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Entities
{
    public class Job 
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public bool IsActive { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public long CompanyUserId { get; set; }
        public string Type { get; set; }
        public string Benefit { get; set; }
        public decimal Salary { get; set; }
        public DateTime ExpirationTime { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public DateTime DeleteDate { get ; set ; }
        public long? UpdateUserInfo { get ; set ; }
        public long? CreateUserInfo { get ; set ; }
        public long? DeleteUserInfo { get ; set ; }
        public int Score { get; set; }
    }
}
