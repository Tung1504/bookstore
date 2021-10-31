using bookstore.DAO;
using bookstore.Models;
using bookstore.ViewModels.PublisherProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class PublisherProductController : BaseController
    {
        BookDAO bookDAO;
        PublisherDAO publisherDAO;

        public PublisherProductController(BookDAO bookDAO, PublisherDAO publisherDAO)
        {
            this.bookDAO = bookDAO;
            this.publisherDAO = publisherDAO;
        }

        // GET: PublisherProduct
        public ActionResult Index(int id, int? page)
        {
            List<Book> books = bookDAO.Where(p => p.publisher_id == id).ToList();
            int limit = 5;
            int start = page == null ? 1 : (Convert.ToInt32(page) - 1) * limit;
            int totalBook = books.Count();
            int numberPage = Convert.ToInt32(Math.Ceiling((double)totalBook / limit));
            List<Book> paginatedBooks = books.OrderByDescending(s => s.id).Skip(start).Take(limit).ToList();

            Publisher publisher = publisherDAO.Find(id);

            PublisherProductViewModel publisherProductViewModel = new PublisherProductViewModel()
            {
                Publisher = publisher,
                Books = paginatedBooks
            };

            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = page == null ? 1 : page; ;
            ViewBag.numberPage = numberPage;

            return View(publisherProductViewModel);
        }
    }
}