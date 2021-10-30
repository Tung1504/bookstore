using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.Cart
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public int Quantity { get; set; }

        public CartViewModel() { }

        public CartViewModel(List<CartItem> cartItems)
        {
            CartItems = cartItems;            
        }

    }
}