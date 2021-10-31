using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<Book> ListBook { get; set; }

        public List<Category> ListCategory { get; set; }

        public HomeViewModel() { }

        public HomeViewModel(List<Book> _ListBook, List<Category> categories)
        {
            this.ListBook = _ListBook;
            this.ListCategory = categories;
        }
    }
}