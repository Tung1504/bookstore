using bookstore.Controllers;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        // GET: Admin/ManageBook
        public ActionResult Index()
        {
            List<Book> listBook = db.Books.ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(listBook);
        }

        public ActionResult Create()
        {
            Book book = new Book();
            List<Author> authors = db.Authors.ToList();
            List<Publisher> publishers = db.Publishers.ToList();
            List<Category> categories = db.Categories.ToList();

            BookCategoryPublisherAuthorViewModel bookCategoryPublisherViewModel = new BookCategoryPublisherAuthorViewModel(book, categories, publishers, authors);
            return View(bookCategoryPublisherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase upload_image)
        {
            // #TODO: save duong dan file image vao images/shop..

            if (ModelState.IsValid)
            {
                if (upload_image != null && upload_image.ContentLength > 0)
                {
                    int id = int.Parse(db.Books.ToList().Last().id.ToString());
                    string _FileName = "";
                    int index = upload_image.FileName.IndexOf('.');
                    _FileName = "book" + id.ToString() + '.' + upload_image.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/images/shop"), _FileName);

                    upload_image.SaveAs(_path);

                    //UploadService.Upload(file, string savePath)

                    Book b = db.Books.FirstOrDefault(x => x.id == id);
                    b.image = _FileName;
                    db.SaveChanges();
                }
                //db.Books.Add(book);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(book);
        }

        public ActionResult ViewDetail(int id)
        {
            Book book = db.Books.Find(id);
            Category category = db.Categories.Where(m => m.id == book.category_id).FirstOrDefault();
            Publisher publisher = db.Publishers.Where(m => m.id == book.publisher_id).FirstOrDefault();
            Author author = db.Authors.Where(m => m.id == book.author_id).FirstOrDefault();

            BookCategoryPublisherAuthorViewModel bookCategoryPublisherAuthorViewModel = new BookCategoryPublisherAuthorViewModel(book, category, publisher, author);

            return View(bookCategoryPublisherAuthorViewModel);
        }

        public ActionResult Edit(int id)
        {
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            List<Author> authors = db.Authors.ToList();
            List<Publisher> publishers = db.Publishers.ToList();
            List<Category> categories = db.Categories.ToList();

            BookCategoryPublisherAuthorViewModel bookCategoryPublisherAuthorViewModel = new BookCategoryPublisherAuthorViewModel(book, categories, publishers, authors);
            return View(bookCategoryPublisherAuthorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book, HttpPostedFileBase upload_image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = System.Data.EntityState.Modified;
                //db.SaveChanges();

                // generate image file name (eg. book27.png)
                int index = upload_image.FileName.IndexOf('.');
                string _FileName = "book" + id.ToString() + '.' + upload_image.FileName.Substring(index + 1);

                // save image file 
                if (upload_image != null && upload_image.ContentLength > 0)
                {
                    string _path = Path.Combine(Server.MapPath("~/images/shop"), _FileName);
                    upload_image.SaveAs(_path);
                }

                // update image file name of the book
                Book b = db.Books.FirstOrDefault(x => x.id == id);
                b.image = _FileName;
                db.SaveChanges();
                TempData["result"] = "Edit book detail successfully!";
                
                return RedirectToAction("Index");
            }
            
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                TempData["result"] = "Delete book successfully!";
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}

