using bookstore.Areas.Admin.ViewModels;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/ManageCategory
        public ActionResult Index()
        {
      
            List<Category> listCategory = db.Categories.ToList();
            return View(listCategory);
        }
        //POST: Admin/Create Modal
        //[HttpPost]
        //public ActionResult Index(Category category)
        //{
            
            
        //        db.Categories.Add(createCategory.Category);
        //        db.SaveChanges();
        //    int id = createCategory.Category.id;
              
            
        //    return View(createCategory);
        //}


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges(); //Apply insert statement
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}