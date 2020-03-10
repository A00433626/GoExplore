using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Areas.Admin.Models
{
    public class RegistrationModel
    {
        [Display(Name="User Id")]
        public int UserID { get; set; }

        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Please Enter User Name")]
        public string UserName { get; set; }

        [Display(Name ="Email Id")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Please Enter Valid Email Id")]
        public string EmailId { get; set; }


        public string UserType { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Both Password and Retype Password Must be Same")]
        public string ConfirmPassword { get; set; }

        /*
        [Display(Name = "Terms and Conditions")]
        [CheckBoxRequired(ErrorMessage = "Please accept the terms and condition.")]
        public bool TermsAndConditions { get; set; }
        */
    }
}