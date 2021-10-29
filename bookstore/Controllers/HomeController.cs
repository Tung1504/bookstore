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
using bookstore.DAO;

namespace bookstore.Controllers
{
    public class HomeController : BaseController
    {
        BookDAO bookDAO;
        CategoryDAO categoryDAO;

        public HomeController(BookDAO bookDAO, CategoryDAO categoryDAO)
        {
            this.bookDAO = bookDAO;
            this.categoryDAO = categoryDAO;
        }

        public ActionResult Index()
        {
            List<Book> books = bookDAO.All();
            BookCategoryPublisherAuthorViewModel bookCategoryPublisherAuthorViewModel = new BookCategoryPublisherAuthorViewModel()
            {
                ListCategory = categoryDAO.All(),
                ListBook = books
            };
            return View(bookCategoryPublisherAuthorViewModel);
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
            List<Book> listBook = this.bookDAO.Where(b => b.title.Contains(search) || search == null).ToList();
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
            int numberPage = (totalBook / limit);
            List<Book> paginated_listBook = listBook.OrderByDescending(s => s.id).Skip(start).Take(limit).ToList();

            List<Category> listCategory = categoryDAO.All();
            //List<Publisher> listPublisher = publisherDAO.All();
            //BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(paginated_listBook, listCategory, listPublisher);

            ViewBag.numberPage = numberPage;
            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = page;
            ViewBag.search = search;
            return View();
        }

        
    }
}