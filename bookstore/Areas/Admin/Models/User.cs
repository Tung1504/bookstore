using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {

    }




    public class UserMetadata
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "Password must be 8-24 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).*$", ErrorMessage = "Password must contain at least 1 uppercase, 1 lowercase, 1 digit, 1 special character")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, type again!")]
        public string repassword { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Please assign role for the user")]
        public string role { get; set; }

        [Required(ErrorMessage = "Please enter user email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please choose date of birth")]
        public DateTime dob { get; set; }
    }
}