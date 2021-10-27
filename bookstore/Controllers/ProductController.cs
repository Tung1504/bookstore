using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Detail(int id)
        {
            //Book book = db.Books.Find(id);
            //Category category = db.Categories.Where(m => m.id == book.category_id).FirstOrDefault();
            //Publisher publisher = db.Publishers.Where(m => m.id == book.publisher_id).FirstOrDefault();
            //Author author = db.Authors.Where(m => m.id == book.author_id).FirstOrDefault();
            //List<Category> listCategory = db.Categories.ToList();
            //List<Publisher> listPublisher = db.Publishers.ToList();
            //List<Author> listAuthor = db.Authors.ToList();
            //List<Book> listBook = db.Books.ToList();

            //BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(book, category, publisher, author, listBook, listCategory, listPublisher, listAuthor);

            //if (book == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(bookCategoryPublisherViewModel);
            return Content("1");
        }
    }
}