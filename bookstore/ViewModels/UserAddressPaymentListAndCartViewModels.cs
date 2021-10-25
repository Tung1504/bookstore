using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class UserAddressPaymentListAndCartViewModels
    {

        public UserAddressPaymentListAndCartViewModels()
        {
        }

        public UserAddressPaymentListAndCartViewModels(User user, List<Address> addressL, List<Payment_card> paymentCardL,  List<CartItem> C)
        {
            User = user;
            AddressList = addressL;
            PaymentCardList = paymentCardL;
            this.CartItemsList = C;
        }

        public User User { get; set; }
        public List<Address> AddressList { get; set; }
        public List<Payment_card> PaymentCardList { get; set; }
        public List<CartItem> CartItemsList { get; set; }
    }
}