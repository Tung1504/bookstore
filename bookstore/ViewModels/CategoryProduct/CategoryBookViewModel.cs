using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.CategoryProduct
{
    public class CategoryBookViewModel
    {

        public CategoryBookViewModel()
        {

        }

        public CategoryBookViewModel(Category category, List<Book> books)
        {
            Category = category;
            Books = books;
        }

        public Category Category;

        public List<Book> Books { get; set; }

    }
}