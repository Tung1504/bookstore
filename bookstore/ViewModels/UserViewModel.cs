using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


//not used (only used with UserInformation.cshtml when updated)
namespace bookstore.ViewModels
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string name { get; set; }

        // only for UpdateInformation (not require password anymore)
        [Required(ErrorMessage = "'username' field is required")]
        public string username { get; set; }

        public string password { get; set; }

        public string repassword { get; set; }


        public string role { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> dob { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment_card> Payment_card { get; set; }

    }
}