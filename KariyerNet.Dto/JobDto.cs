using KariyerNet.Data.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Dto
{
    public class JobDto
    {
        [BsonId]
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string Description { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "{0} alanı 0 dan büyük olmalıdır..")]
        public long CompanyId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "{0} alanı 0 dan büyük olmalıdır..")]
        public long CompanyUserId { get; set; }
        public string Type { get; set; }
        public string Benefit { get; set; }
        public decimal Salary { get; set; }
        public DateTime ExpirationTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public int Score { get; set; }
    }
}
