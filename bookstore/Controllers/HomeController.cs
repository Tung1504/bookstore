using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.ViewModels;

namespace bookstore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<Book> listBook = db.Books.ToList();
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();

           

            BookCategoryPublisherViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherViewModel(listBook, listCategory, listPublisher);
            
            return View(bookCategoryPublisherViewModel);
        }

        public ActionResult Cart()
        { 

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }
    }
}