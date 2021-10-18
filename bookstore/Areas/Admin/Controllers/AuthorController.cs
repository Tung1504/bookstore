using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/ManageAuthor
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetData()
        {
            List<Author> authors = db.Authors.ToList();
            return Json(new { data = authors }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new Author());
            }
            else
            {
                return View(db.Authors.Where(i => i.id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Author author)
        {
            if(author.id == 0)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return Json(new { success = true, message = "Create Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Entry(author).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
           
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            
                Author author = db.Authors.Where(x => x.id == id).FirstOrDefault();
                db.Authors.Remove(author);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            
        }



        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Author author)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Authors.Add(author);
        //        db.SaveChanges(); //Apply insert statement
        //        return RedirectToAction("Index");
        //    }

        //    //nếu validate thất bại
        //    return View(author);
        //}

        //public ActionResult Edit(int id)
        //{
        //    Author author = db.Authors.Find(id);
        //    if (author == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(author);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Author author)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(author).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(author);

        //}

        //public JsonResult EditCustomer(int id)
        //{
        //    var author = db.Authors.Find(id);
        //    return Json(author, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    Author author = db.Authors.Find(id);
        //    if (author != null)
        //    {
        //        db.Authors.Remove(author);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return HttpNotFound();
        //}
    }
}