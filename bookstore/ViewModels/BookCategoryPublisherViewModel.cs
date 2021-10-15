using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class BookCategoryPublisherViewModel
    {
        //public Book Book { get; set; }
        //public Category Category { get; set; }
        //public Publisher Publisher { get; set; }

        public List<Book> ListBook { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Publisher> ListPublisher { get; set; }

        public BookCategoryPublisherViewModel() { }

        public BookCategoryPublisherViewModel(List<Book> _listBook, List<Category> _listCategory, List<Publisher> _listPublisher)
        {
          
            this.ListBook = _listBook;
            this.ListCategory = _listCategory;
            this.ListPublisher = _listPublisher;
        }

       
    }
}