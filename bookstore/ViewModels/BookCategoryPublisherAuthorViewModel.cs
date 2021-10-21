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

        public List<Book> ListBook { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Publisher> ListPublisher { get; set; }
        public List<Author> ListAuthor { get; set; }

        public BookCategoryPublisherAuthorViewModel() { }

        public BookCategoryPublisherAuthorViewModel(List<Book> _listBook, List<Category> _listCategory, List<Publisher> _listPublisher)
        {
          
            this.ListBook = _listBook;
            this.ListCategory = _listCategory;
            this.ListPublisher = _listPublisher;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, List<Category> listCategory, List<Publisher> listPublisher, List<Author> listAuthor)
        {
            Book = book;
            this.ListCategory = listCategory;
            this.ListPublisher = listPublisher;
            this.ListAuthor = listAuthor;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, Category category, Publisher publisher, Author author)
        {
            Book = book;
            Category = category;
            Publisher = publisher;
            Author = author;
        }

        public BookCategoryPublisherAuthorViewModel(List<Book> bs, List<Category> cs, List<Author> aus, List<Publisher> ps)
        {
            this.ListBook = bs;
            this.ListCategory = cs;
            this.ListAuthor = aus;
            this.ListPublisher = ps;
        }
    }
}