using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class AddressAndPayment
    {
        public Address Address { get; set; }
        public Payment_card Payment_card { get; set; }
        public AddressAndPayment()
        {

        }
        public AddressAndPayment(Address a,Payment_card p)
        {
            this.Address = a;
            this.Payment_card = p;
        
        }
    }
}