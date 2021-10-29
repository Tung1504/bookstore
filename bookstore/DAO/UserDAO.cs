using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using bookstore.Models;
using bookstore.ViewModels;

namespace bookstore.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        [Required(ErrorMessage = "The reentered password field is required")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, type again!")]
        [NotMapped]
        public string repassword { get; set; }
    }

    public class UserMetadata
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "Password must be 8-24 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).*$", ErrorMessage = "Password must contain at least 1 uppercase, 1 lowercase, 1 digit, 1 special character")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required]
        public string role { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public Nullable<System.DateTime> dob { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment_card> Payment_card { get; set; }
    }
}