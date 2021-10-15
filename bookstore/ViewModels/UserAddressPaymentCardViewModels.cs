using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class UserAddressPaymentCardViewModels
    {

        public User User { get; set; }
        public Address Address { get; set; }
        public Payment_card PaymentCard { get; set; }

        List<Address> ListAddress { get; set; }

        public UserAddressPaymentCardViewModels()
        {
        }

        public UserAddressPaymentCardViewModels(User user, Address address, Payment_card paymentCard)
        {
            this.User = user;
            this.Address = address;
            this.PaymentCard = paymentCard;
        }

        public UserAddressPaymentCardViewModels(User user, List<Address> listAddress, Payment_card payment_Card)
        {
            this.User = user;
            this.ListAddress = listAddress;
            this.PaymentCard = payment_Card;
        }

       
       
    }
}