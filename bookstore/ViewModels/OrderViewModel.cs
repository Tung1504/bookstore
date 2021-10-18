using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public Order_Detail OrderDetail { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public Payment_card Payment_Card { get; set; }

        public List<Order_Detail> ListOrderDetail { get; set; }
        public OrderViewModel() { }

        public OrderViewModel(Order order, Order_Detail order_Detail, User user, Address address, Payment_card payment_Card, List<Order_Detail> order_Details)
        {
            this.Order = order;
            this.OrderDetail = order_Detail;
            this.User = user;
            this.Address = address;
            this.Payment_Card = payment_Card;
            this.ListOrderDetail = order_Details;
        }

        
    }
}