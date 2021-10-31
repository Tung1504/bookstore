using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class UserPaymentListAndAddressListViewModels
    {
        public User User { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter payment")]
        public string Payment { get; set; }
        public string Note { get; set; }

        public AddressAndPayment AddressAndPayment { get; set; }
        public List<Address> AddressList { get; set; }
        public List<Payment_card> PaymentCardList { get; set; }
        public UserPaymentListAndAddressListViewModels()
        {
        }

        public UserPaymentListAndAddressListViewModels(User u, List<Address> addressL, List<Payment_card> paymentCardL, AddressAndPayment ap)
        {
            User = u;
            AddressList = addressL;
            PaymentCardList = paymentCardL;
            AddressAndPayment = ap;


        }
        public UserPaymentListAndAddressListViewModels(string address, string paymentCard)
        {
            Address = address;
            Payment = paymentCard;
        }

    }
}