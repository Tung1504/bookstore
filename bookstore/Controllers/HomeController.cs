﻿using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.ViewModels;
using System.Web.Security;
using System.IO;

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
                Session["Id"] = user.id.ToString();
                Session["UserName"] = user.username;

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