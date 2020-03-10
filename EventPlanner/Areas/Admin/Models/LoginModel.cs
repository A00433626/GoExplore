using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Areas.Admin.Models
{
    public class LoginModel
    {
        [Display(Name ="Email Id")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email Id")]
        public string EmailId { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}