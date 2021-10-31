using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.PublisherProduct
{
    public class PublisherProductViewModel
    {

        public PublisherProductViewModel()
        {

        }

        public PublisherProductViewModel(Publisher publisher, List<Book> books)
        {
            Publisher = publisher;
            Books = books;
        }

        public Publisher Publisher;

        public List<Book> Books { get; set; }

    }
}