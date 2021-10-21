using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Models.Home
{
    public class Item
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
   
        public Item(Book b, int q)
        {
            this.Book = b;
            this.Quantity = q;
          
            
        }
    }
}