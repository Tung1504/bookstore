using bookstore.Areas.Admin.ViewModels;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Admin
    
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            List<Author> authors = db.Authors.ToList();
            List<Category> categories = db.Categories.ToList();
            List<Publisher> publishers = db.Publishers.ToList();
            BookCategoryAuthorPublisherViewModels bookCategoryAuthorPublisherViewModels = new BookCategoryAuthorPublisherViewModels(books.ToList(), categories, authors, publishers);
            return View(bookCategoryAuthorPublisherViewModels);
        }


    }
}