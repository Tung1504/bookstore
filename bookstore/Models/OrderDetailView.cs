using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class OrderDetailView
    {
        public Order Order { get; set; }
        public List<Order_Detail> OrderDetails { get; set; }
        public OrderDetailView(Order o, List<Order_Detail> odList)
        {
            this.Order = o;
            this.OrderDetails = odList;
        }
    }
}