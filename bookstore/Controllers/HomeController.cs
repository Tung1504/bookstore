
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.ViewModels;
using System.Web.Security;
using System.IO;
using bookstore.ViewModels.Home;

namespace bookstore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<Book> listBook = db.Books.ToList();
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();



            HomeViewModel homeViewModel = new HomeViewModel(listBook, listCategory);

            return View(homeViewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }




        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public ActionResult Shop(int? page, string search)
        {


            List<Book> listBook = db.Books.Where(b => b.title.Contains(search) || search == null).ToList();
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int limit = 5;
            int start = (int)(page - 1) * limit;
            int totalBook = listBook.Count();
            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = page;
            int numberPage = (totalBook / limit);
            ViewBag.numberPage = numberPage;
            List<Book> paginated_listBook = listBook.OrderByDescending(s => s.id).Skip(start).Take(limit).ToList();

            ViewBag.search = search;


            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();



            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(paginated_listBook, listCategory, listPublisher);

            return View(bookCategoryPublisherViewModel);
        }

       

      

        public ActionResult Cart()
        {

            return View();
        }

    }
}
