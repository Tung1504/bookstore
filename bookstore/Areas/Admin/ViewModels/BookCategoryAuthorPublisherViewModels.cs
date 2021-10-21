using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.ViewModels
{
    public class BookCategoryAuthorPublisherViewModels
    {
        public List<Book> Books { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public BookCategoryAuthorPublisherViewModels(List<Book> bs, List<Category> cs, List<Author> aus, List<Publisher> ps)
        {
            this.Books = bs;
            this.Categories = cs;
            this.Authors = aus;
            this.Publishers = ps;
        }
    }
}