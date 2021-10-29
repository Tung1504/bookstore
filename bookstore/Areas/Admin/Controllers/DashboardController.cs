using bookstore.ViewModels;
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
    public class DashboardController : BaseController
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            List<Book> book = db.Books.ToList();
            List<Author> authors = db.Authors.ToList();
            List<Category> categories = db.Categories.ToList();
            List<Publisher> publishers = db.Publishers.ToList();
            List<Order> order = db.Orders.ToList();

            AdminDashboardViewModel adminDashboardViewModel = new AdminDashboardViewModel(users, book, categories, publishers, authors, order);
            return View(adminDashboardViewModel);
        }


    }
}