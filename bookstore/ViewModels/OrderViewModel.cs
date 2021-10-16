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

        public OrderViewModel() { }

        public OrderViewModel(Order order, Order_Detail order_Detail)
        {
            this.Order = order;
            this.OrderDetail = order_Detail;
        }
    }
}