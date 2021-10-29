using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.ProductDetailViewModel
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {
        }

        public ProductDetailViewModel(Book book, Category category, Publisher publisher, Author author)
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

    }
}