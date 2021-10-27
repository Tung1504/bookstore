using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace bookstore.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/ManageAuthor
        public ActionResult Index()
        {
            List<Author> listAuthor = db.Authors.ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(listAuthor);
        }

        public ActionResult GetData()
        {
            //List<Author> listAuthor = db.Authors.ToList();
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;

                var data = db.Authors.ToList();

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
            var item = db.Authors.Find(id);
            return Json(new { data = item }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Edit(int id)
        //{

        //    //if (author.id > 0)
        //    //{
        //    //db.Authors.Attach(author);
        //    var listAuthor = db.Authors.Find(id);
        //    //listAuthor.id = author.id;
        //    //listAuthor.author_name = author.author_name;
        //    db.Entry(listAuthor).State = System.Data.EntityState.Modified;
        //    TempData["result"] = "Edit author successfully!";
        //    db.SaveChanges();

        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    db.Authors.Add(author);
        //    //    try
        //    //    {

        //    //        db.SaveChanges();
        //    //        this.AddNotification("Success", NotificationType.SUCCESS);
        //    //        return Json(new { success = true });
        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        Console.WriteLine(e);
        //    //        return Json(new { success = false });
        //    //    }
        //    //}
        //}

        public ActionResult Edit(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                TempData["result"] = "Edit author successfully!";
                return RedirectToAction("Index");
            }

            return View(author);
        }

        [HttpPost]
        public JsonResult DeleteRecord(int id)
        {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            var result = db.SaveChanges();
            if (result > 0)
            {
                TempData["result"] = "Delete author successfully!";
                return Json(new { success = true });
            }
            else
            {
                TempData["result"] = "Delete author failed!";
                return Json(new { success = false });
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    if (order != null)
        //    {
        //        db.Orders.Remove(order);
        //        db.SaveChanges();
        //        TempData["result"] = "Delete author successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["result"] = "Delete author failed sucefully!";
        //    return HttpNotFound();
        //}


        public ActionResult ViewDetail(int id)
        {
            Author author = db.Authors.Find(id);
            return View(author);
        }

        public ActionResult Create()
        {
            Author author = new Author();
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author, HttpPostedFileBase upload_image)
        {

            if (ModelState.IsValid)
            {
                if (upload_image != null && upload_image.ContentLength > 0)
                {
                    int id = int.Parse(db.Authors.ToList().Last().id.ToString());
                    string _FileName = "";
                    int index = upload_image.FileName.IndexOf('.');
                    _FileName = "author" + id.ToString() + '.' + upload_image.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/images/author"), _FileName);

                    upload_image.SaveAs(_path);

                    

                    Author a = db.Authors.FirstOrDefault(x => x.id == id);
                    a.image = _FileName;

                    db.SaveChanges();
                    TempData["result"] = "Create new author successfully!";
                }
                //db.Authors.Add(author);
                //db.SaveChanges();
                //TempData["result"] = "Create new author successfully!";
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(author);
        }

    }
}