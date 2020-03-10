using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Models
{
    public class CreditcardDetails
    {
        public string Gender { get; set; }
        [RegularExpression(@"^4[0-9]{15}$|^5[1-5][0-9]{14}$|^34[0-9]{13}$|^37[0-9]{13}$")]
        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [Range(100, 999)]
        public int CVV { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string NameOnCard { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|10|11|12)/(201[6-9]$|20[2][0-9]$|20[3][0-6]$)")]
        public string ExpiryDate { get; set; }
    }
}