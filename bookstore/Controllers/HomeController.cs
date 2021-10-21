﻿using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore.ViewModels;
using System.Web.Security;
using bookstore.Models.Home;

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
        public ActionResult AddToCart()
        {

            return View();

        }
        /// <summary>
        /// Add to cart handler
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult AddToCart(int bookId)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Book book = db.Books.Find(bookId);
                cart.Add(new Item(book, 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var book = db.Books.Find(bookId);
                foreach (var item in cart)
                {
                    if (item.Book.id == bookId)
                    {
                        int previous_quantity = item.Quantity;
                        cart.Remove(item);
                        cart.Add(new Item(book, previous_quantity + 1));
                        break;
                        
                    }

                    else
                    {
                        cart.Add(new Item(book, 1));
                        break;
                        
                    }
                }
                Session["cart"] = cart;
            }


            return RedirectToAction("Index");
        }
        //public ActionResult DecreaseItem(int bookId) 
        //{

        //}
        public ActionResult RemoveFromCart(int bookId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            // var book = db.Books.Find(bookId);
            foreach (var item in cart)
            {
                if (item.Book.id == bookId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            // cart.Add(new Item(book, 1));
            Session["cart"] = cart;
            return RedirectToAction("AddToCart");
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