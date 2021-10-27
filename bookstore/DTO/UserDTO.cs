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
    public partial class User
    {
        public const string CUSTOMER = "Customer";
        public const string ADMIN = "Admin";

        public User(string username, string name, string password, string email, string role, string phone, DateTime dob)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.role = role;
            this.phone = phone;
            this.dob = dob;
        }
    }

    public class UserMetadata
    {
       
    }
}