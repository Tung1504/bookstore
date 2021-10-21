using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using bookstore.Extensions;

namespace bookstore.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/ManageAuthor
        public ActionResult Index()
        {
            List<Category> listCategory = db.Categories.ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(listCategory);
        }

        public ActionResult GetData()
        {
            
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;

                var data = db.Categories.ToList();

                return Json(new { Data = data, TotalItems = data.Count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                //restore ProxyCreation to its original state
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }

        public ActionResult GetById(int id)
        {
            var item = db.Categories.Find(id);
            return Json(new { data = item }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Category category)
        {

            if (category.id > 0)
            {
                db.Categories.Attach(category);
                db.Entry(category).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                TempData["result"] = "Edit category successfully!";
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Categories.Add(category);
                try
                {

                    db.SaveChanges();
                    TempData["result"] = "Create new category successfully!";
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Json(new { success = false });
                }
            }
        }

        //[HttpPost]
        //public ActionResult Edit(Author author)
        //{
        //    if (author.id > 0)
        //    {
        //        db.Authors.Attach(author);
        //        var listAuthor = db.Authors.Find(author.id);
        //        listAuthor.id = author.id;
        //        listAuthor.author_name = author.author_name;
        //        db.Entry(author).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public JsonResult DeleteRecord(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            var result = db.SaveChanges();
            if (result > 0)
            {
                TempData["result"] = "Delete category successfully!";
                return Json(new { success = true });
            }
            else
            {
                TempData["result"] = "Delete category failed successfully!";
                return Json(new { success = false });
            }
        }


    }
}