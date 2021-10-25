using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class UserPaymentListAndAddressListViewModels
    {
        public User User { get; set; }
        public Address Address { get; set; }
        public Payment_card Payment { get; set; }
        public AddressAndPayment AddressAndPayment { get; set; }
        public List<Address> AddressList { get; set; }
        public List<Payment_card> PaymentCardList { get; set; }
        public UserPaymentListAndAddressListViewModels()
        {
        }

        public UserPaymentListAndAddressListViewModels(User u, List<Address> addressL, List<Payment_card> paymentCardL,AddressAndPayment ap)
        {
            User = u;
            AddressList = addressL;
            PaymentCardList = paymentCardL;
            AddressAndPayment = ap;
           
        }
        public UserPaymentListAndAddressListViewModels(Address a,Payment_card p)
        {
            this.Address = a;
            this.Payment = p;
        }

    }
}