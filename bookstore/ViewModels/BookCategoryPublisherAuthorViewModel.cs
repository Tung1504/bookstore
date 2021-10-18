using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class BookCategoryPublisherAuthorViewModel
    {
        public Book Book { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }

        public List<Book> listBook { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Publisher> listPublisher { get; set; }
        public List<Author> listAuthor { get; set; }

        public BookCategoryPublisherAuthorViewModel() { }

        public BookCategoryPublisherAuthorViewModel(List<Book> _listBook, List<Category> _listCategory, List<Publisher> _listPublisher)
        {
          
            this.listBook = _listBook;
            this.listCategory = _listCategory;
            this.listPublisher = _listPublisher;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, List<Category> listCategory, List<Publisher> listPublisher, List<Author> listAuthor)
        {
            Book = book;
            this.listCategory = listCategory;
            this.listPublisher = listPublisher;
            this.listAuthor = listAuthor;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, Category category, Publisher publisher, Author author)
        {
            Book = book;
            Category = category;
            Publisher = publisher;
            Author = author;
        }
    }
}