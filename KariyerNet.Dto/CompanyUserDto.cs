using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Dto
{
    public class CompanyUserDto
    {
        public long CompanyUserId { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir..")]
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "{0} alanı 0 dan büyük olmalıdır..")]
        public long CompanyId { get; set; }
    }
}
