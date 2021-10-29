using bookstore.DAO;
using bookstore.Models;
using bookstore.ViewModels.Home;
using bookstore.ViewModels.ProductDetailViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class ProductController : BaseController
    {
        CategoryDAO categoryDAO;
        PublisherDAO publisherDAO;
        BookDAO bookDAO;
        AuthorDAO authorDAO;

        public ProductController(CategoryDAO categoryDAO, PublisherDAO publisherDAO, BookDAO bookDAO, AuthorDAO authorDAO)
        {
            this.categoryDAO = categoryDAO;
            this.publisherDAO = publisherDAO;
            this.bookDAO = bookDAO;
            this.authorDAO = authorDAO;
        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            Book book = bookDAO.Find(id);
            Category category = categoryDAO.FirstOrDefault(m => m.id == book.category_id);
            Publisher publisher = publisherDAO.FirstOrDefault(m => m.id == book.publisher_id);
            Author author = authorDAO.FirstOrDefault(m => m.id == book.author_id);   
            List<Author> listAuthor = authorDAO.All();
            List<Book> listBook = bookDAO.All();

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel()
            {
                Category = category,
                Book = book,
                Author = author,
                Publisher = publisher
            };

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(productDetailViewModel);
        }
    }
}