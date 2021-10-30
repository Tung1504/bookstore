using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class CartItem
    {
        public Book Book { get; set; } 

        public int Quantity { get; set; }

        public CartItem()
        {

        }

        public CartItem (Book b, int q)
        {
            this.Book = b;
            this.Quantity = q;
        }
        public double Linetotal
        {
            get
            {
                return Book.price * Quantity;
            }
        }
    }
}