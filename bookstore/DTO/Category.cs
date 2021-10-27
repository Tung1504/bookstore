using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using bookstore.Areas.Admin.Controllers;
using bookstore.Models;
using bookstore.ViewModels;

namespace bookstore.Models
{

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
        //BookStoreEntities db = new BookStoreEntities();

        //public List<Book> findBookByCategory()
        //{
        //    List<Book> listBook = db.Books.Where(b => b.category_id == id).ToList();
        //    return listBook;
        //}
    }

    public class CategoryMetadata
    {
        public int id { get; set; }
        public string category_name { get; set; }

        public virtual ICollection<Book> Books { get; set; }


    }
}