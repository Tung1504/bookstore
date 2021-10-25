using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels
{
    public class AdminDashboardViewModel
    {
        public Book Book { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }
        public Order Order { get; set; }
        public User user { get; set; }

        public List<Book> ListBook { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Publisher> ListPublisher { get; set; }
        public List<Author> ListAuthor { get; set; }
        public List<Order> ListOrder { get; set; }
        public List<User> ListUser { get; set; }


        public AdminDashboardViewModel() { }

        public AdminDashboardViewModel(List<User> _listUser, List<Book> _listBook, List<Category> _listCategory, List<Publisher> _listPublisher, List<Author> _listAuthor, List<Order> _listOrder)
        {
            this.ListUser = _listUser;
            this.ListBook = _listBook;
            this.ListCategory = _listCategory;
            this.ListPublisher = _listPublisher;
            this.ListAuthor = _listAuthor;
            this.ListOrder = _listOrder;
        }
    }
}