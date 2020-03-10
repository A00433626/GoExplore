using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Helper
{
    public class PaymentModel
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int SeatsOccupied { get; set; }
        [Required(ErrorMessage = "* required")]
        public decimal TotalAmount { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "* required")]
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public String PaymentMode { get; set; }
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "* required")]
        public string CardType { get; set; }

        [RegularExpression(@"^4[0-9]{15}$|^5[1-5][0-9]{14}$|^34[0-9]{13}$|^37[0-9]{13}$", ErrorMessage = "Invalid Card Numbner")]
        [Required(ErrorMessage = "* required")]
        [StringLength(16)]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "* required")]
        [Range(100, 999)]
        public int CVV { get; set; }
        [Required(ErrorMessage = "* required")]
        [StringLength(60, MinimumLength = 10)]
        public string NameOnCard { get; set; }
        [Required(ErrorMessage = "* required")]
        //[RegularExpression(@"^(0[1-9]|10|11|12)/(201[6-9]$|20[2][0-9]$|20[3][0-6]$)")]
        public string ExpiryMonth { get; set; }
        [Required(ErrorMessage = "* required")]

        public string PhoneNumber { get; set; }

        public int ExpiryYear { get; set; }

        
    }
}