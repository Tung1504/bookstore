
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            user.role = "Customer";
            if (db.Users.Any(x => x.username == user.username))
            {

                ViewBag.SignUpFail = "This account has already existed";
                return View("~/Views/Home/LoginOrSignUp.cshtml");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);

                    db.SaveChanges();

                    Session["Id"] = user.id.ToString();
                    Session["UserName"] = user.username;
                    Session["Role"] = user.role;

                    return RedirectToAction("Index", "Home");
                }
            }

            return View("~/Views/Home/LoginOrSignUp.cshtml");


        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        public ActionResult LoginOrSignUp()
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
                Session["Id"] = u.id.ToString();
                Session["UserName"] = u.username;
                Session["Role"] = u.role;
                Session["auth"] = u;

                if (u.role == "Customer")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (u.role == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                }
            }
            else
            {
                ViewBag.LoginFail = "Wrong UserName or Password";
            }

            return View("~/Views/Home/LoginOrSignUp.cshtml");
        }


      

        public ActionResult Cart()
        {

            return View();
        }

    }
}
