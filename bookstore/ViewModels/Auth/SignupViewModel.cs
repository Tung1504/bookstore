using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.Auth
{
    public class SignupViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "Password must be 8-24 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).*$", ErrorMessage = "Password must contain at least 1 uppercase, 1 lowercase, 1 digit, 1 special character")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, type again!")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please assign role for the user")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Please enter user email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose date of birth")]
        public DateTime Dob { get; set; }
    }
}