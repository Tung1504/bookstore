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

        public List<Book> listBook { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Publisher> listPublisher { get; set; }

        public BookCategoryPublisherViewModel() { }

        public BookCategoryPublisherViewModel(List<Book> _listBook, List<Category> _listCategory, List<Publisher> _listPublisher)
        {
          
            this.listBook = _listBook;
            this.listCategory = _listCategory;
            this.listPublisher = _listPublisher;
        }
    }
}