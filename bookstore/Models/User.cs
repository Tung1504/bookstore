//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookstore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Addresses = new HashSet<Address>();
            this.Orders = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public System.DateTime dob { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
