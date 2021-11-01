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

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime Dob { get; set; }
    }
}