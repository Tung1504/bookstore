using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.Product
{
    public class DetailViewModel
    {
        public DetailViewModel()
        {
        }

        public DetailViewModel(Book book, Category category, Publisher publisher, Author author)
        {
            Book = book;
            Category = category;
            Publisher = publisher;
            Author = author;
        }

        public Book Book { get; set; }

        public Category Category { get; set; }

        public Publisher Publisher { get; set; }

        public Author Author { get; set; }

        public int Quantity { get; set; } = 1;

    }

}