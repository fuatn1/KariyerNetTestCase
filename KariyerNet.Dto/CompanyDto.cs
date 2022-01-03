using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Dto
{
    public class CompanyDto
    {
        public long CompanyId { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string CompanyAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public int MaxJobAdvertisementCount { get; set; }
    }
}
