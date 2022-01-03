using KariyerNet.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Dto
{
    public class JobDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public long CompanyId { get; set; }
        public DateTime ExpirationTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public int Score { get; set; }
        public virtual List<Offer> Offers { get; set; }
    }
}
