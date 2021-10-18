using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.ViewModels;
using System.Web.Security;

namespace bookstore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<Book> listBook = db.Books.ToList();
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();

           

            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(listBook, listCategory, listPublisher);
            
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

        [HttpPost]
        public ActionResult Login(User user)
        {
            User u = db.Users.FirstOrDefault(p => p.username == user.username && p.password == user.password);
            if (u != null)
            {
                // Login: goc man hinh: camnh
                FormsAuthentication.SetAuthCookie(u.username, false);
                if(u.role == "Customer")
                {
                    return RedirectToAction("Index", "Home");
                }
                if(u.role == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                }
            }
            ViewBag.LoginFail = "Sai roi";
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
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
    }
}