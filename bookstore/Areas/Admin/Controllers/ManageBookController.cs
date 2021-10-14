using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class ManageBookController : BaseController
    {
        // GET: Admin/ManageBook
        public ActionResult Index()
        {
            List<Book> listBook = db.Books.ToList();
            return View(listBook);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges(); //Apply insert statement
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(book);
        }


        public ActionResult ViewDetail(int id)
        {
            Book book= db.Books.Find(id);
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book= db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = System.Data.EntityState.Modified;
                db.SaveChanges();
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
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}