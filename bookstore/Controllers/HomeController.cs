using bookstore.Models;
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


       

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            Book book = db.Books.Find(id);
            Category category = db.Categories.Where(m => m.id == book.category_id).FirstOrDefault();
            Publisher publisher = db.Publishers.Where(m => m.id == book.publisher_id).FirstOrDefault();
            Author author = db.Authors.Where(m => m.id == book.author_id).FirstOrDefault();
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();
            List<Author> listAuthor = db.Authors.ToList();
            List<Book> listBook = db.Books.ToList();

            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(book, category, publisher, author, listBook, listCategory, listPublisher, listAuthor);
                        
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(bookCategoryPublisherViewModel);
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
            int numberPage = (totalBook / limit);
            List<Book> paginated_listBook = listBook.OrderByDescending(s => s.id).Skip(start).Take(limit).ToList();

            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();
            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(paginated_listBook, listCategory, listPublisher);

            ViewBag.numberPage = numberPage;
            ViewBag.totalBook = totalBook;
            ViewBag.pageCurrent = page;
            ViewBag.search = search;
            return View(bookCategoryPublisherViewModel);
        }

        public ActionResult Category(int id, int? page)
        {


            List<Book> listBook = db.Books.Where(b => b.category_id == id).ToList();
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
            Category category = db.Categories.Find(id);
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();
            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(category, paginated_listBook, listCategory, listPublisher);

            return View(bookCategoryPublisherViewModel);
        }

        public ActionResult Publisher(int id, int? page)
        {


            List<Book> listBook = db.Books.Where(b => b.publisher_id == id).ToList();
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



            Publisher publisher = db.Publishers.Find(id);
            List<Category> listCategory = db.Categories.ToList();
            List<Publisher> listPublisher = db.Publishers.ToList();



            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(publisher, paginated_listBook, listCategory, listPublisher);

            return View(bookCategoryPublisherViewModel);
        }
    }
}