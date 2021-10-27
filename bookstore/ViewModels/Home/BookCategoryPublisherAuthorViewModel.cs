using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace bookstore.ViewModels.Home
{
    public class BookCategoryPublisherAuthorViewModel
    {
        public Book Book { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }

        public List<Book> ListBook { get; set; }

        public List<Category> ListCategory { get; set; }

        public List<Author> ListAuthor { get; set; }

        public BookCategoryPublisherAuthorViewModel() { }

        public BookCategoryPublisherAuthorViewModel(List<Book> _ListBook, List<Category> categories)
        {          
            this.ListBook = _ListBook;
            this.ListCategory = categories;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, List<Category> ListCategory, List<Publisher> ListPublisher, List<Author> ListAuthor)
        {
            Book = book;           
            this.ListAuthor = ListAuthor;
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
            this.ListAuthor = aus;
        }

        public BookCategoryPublisherAuthorViewModel(Book book, Category category, Publisher publisher, Author author, List<Book> ListBook, List<Category> ListCategory, List<Publisher> ListPublisher, List<Author> ListAuthor) : this(book, category, publisher, author)
        {
            this.ListBook = ListBook;
            this.ListAuthor = ListAuthor;
        }


        public BookCategoryPublisherAuthorViewModel(Category category, List<Book> listBook, List<Category> listCategory, List<Publisher> listPublisher)
        {
            Category = category;
            ListBook = listBook;
        }

        public BookCategoryPublisherAuthorViewModel(Publisher publisher, List<Book> listBook, List<Category> listCategory, List<Publisher> listPublisher)
        {
            Publisher = publisher;
            ListBook = listBook;
        }
    }
}