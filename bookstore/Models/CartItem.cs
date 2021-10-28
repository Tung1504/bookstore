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
        public int UserId { get; set; }
        public CartItem(Book b, int q, int id)

        {
            this.Book = b;
            this.Quantity = q;
            this.UserId = id;
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