using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.ViewModels
{
    public class BookCategoryAuthorPublisherViewModels
    {
        public List<Book> books { get; set; }
        public List<Category> categories { get; set; }
        public List<Author> authors { get; set; }
        public List<Publisher> publishers { get; set; }
        public BookCategoryAuthorPublisherViewModels(List<Book> bs, List<Category> cs, List<Author> aus, List<Publisher> ps)
        {
            this.books = bs;
            this.categories = cs;
            this.authors = aus;
            this.publishers = ps;
        }
    }
}