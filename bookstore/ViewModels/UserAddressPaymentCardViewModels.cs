using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class UserAddressPaymentCardViewModels
    {
        public UserAddressPaymentCardViewModels()
        {
        }

        public UserAddressPaymentCardViewModels(User user, Address address, Payment_card paymentCard)
        {
            User = user;
            Address = address;
            PaymentCard = paymentCard;
        }

        public User User { get; set; }
        public Address Address{ get; set; }
        public Payment_card PaymentCard { get; set; }
    }
}