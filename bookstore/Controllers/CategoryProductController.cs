using bookstore.DAO;
using bookstore.Models;
using bookstore.ViewModels.CategoryProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class CategoryProductController : BaseController
    {
        BookDAO bookDAO;
        CategoryDAO categoryDAO;
        PublisherDAO publisherDAO;

        public CategoryProductController(BookDAO bookDAO, CategoryDAO categoryDAO, PublisherDAO publisherDAO)
        {
            this.bookDAO = bookDAO;
            this.categoryDAO = categoryDAO;
            this.publisherDAO = publisherDAO;
        }

        [Route("Categories/{id}/Products")]
        // GET: CategoryProduct
        public ActionResult Index(int id, int? page)
        {
            List<Book> books = bookDAO.All();            
            int limit = 6;
            int start = page == null ? 1 : (Convert.ToInt32(page) - 1) * limit ;
            int totalBook = books.Count();
            int numberPage = Convert.ToInt32(Math.Ceiling((double)totalBook / limit)); 

            List<Book> paginatedBooks = books.OrderByDescending(s => s.id).Skip(start).Take(limit).ToList();
            Category category = db.Categories.Find(id);
            CategoryBookViewModel bookCategoryPublisherViewModel = new CategoryBookViewModel()
            {
                Category = category,
                Books = paginatedBooks,                
            };

            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = 1;
            ViewBag.numberPage = numberPage;
            return View(bookCategoryPublisherViewModel);
        }
    }
}