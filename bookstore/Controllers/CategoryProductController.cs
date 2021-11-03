﻿using bookstore.DAO;
using bookstore.Models;
using bookstore.ViewModels.CategoryProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class CategoryProductController : BaseController
    {
        BookDAO bookDAO;
        PublisherDAO publisherDAO;

        public CategoryProductController(BookDAO bookDAO, CategoryDAO categoryDAO, PublisherDAO publisherDAO)
        {
            this.bookDAO = bookDAO;
            this.publisherDAO = publisherDAO;
        }

        // GET: CategoryProduct
        public ActionResult Index(int id, int? page)
        {
            List<Book> books = bookDAO.Where(p => p.category_id == id).ToList();
            int limit = 6;
            int start = page == null ? 1 : (Convert.ToInt32(page) - 1) * limit;
            int totalBook = books.Count();
            int numberPage = Convert.ToInt32(Math.Ceiling((double)totalBook / limit));

            List<Book> paginatedBooks = books.OrderByDescending(s => s.id).Take(limit).ToList();
            Category category = db.Categories.Find(id);
            CategoryProductViewModel categoryProductViewModel = new CategoryProductViewModel()
            {
                Category = category,
                Books = paginatedBooks,
            };

            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = page == null ? 1 : page;
            ViewBag.numberPage = numberPage;
            return View(categoryProductViewModel);
        }
    }
}