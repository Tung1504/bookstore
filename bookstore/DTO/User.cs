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
        public const string CUSTOMER = "Customer";
        public const string ADMIN = "Admin";

        public User(int id, string name, string username, string password, string role, string phone, string email, DateTime dob)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.role = role;
            this.phone = phone;
            this.email = email;
            this.dob = dob;
        }
    }

    public class UserMetadata
    {
    }
}