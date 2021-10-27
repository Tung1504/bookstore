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
    public class PublisherController : BaseController
    {
        // GET: Admin/Managepublisher
        public ActionResult Index()
        {
            List<Publisher> listPublisher = db.Publishers.ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(listPublisher);
        }

        public ActionResult GetData()
        {
            //List<publisher> listpublisher = db.publishers.ToList();
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;

                var data = db.Publishers.ToList();

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
            var item = db.Publishers.Find(id);
            return Json(new { data = item }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Edit(int id)
        //{

        //    //if (publisher.id > 0)
        //    //{
        //    //db.publishers.Attach(publisher);
        //    var listpublisher = db.publishers.Find(id);
        //    //listpublisher.id = publisher.id;
        //    //listpublisher.publisher_name = publisher.publisher_name;
        //    db.Entry(listpublisher).State = System.Data.EntityState.Modified;
        //    TempData["result"] = "Edit publisher successfully!";
        //    db.SaveChanges();

        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    db.publishers.Add(publisher);
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
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                TempData["result"] = "Edit publisher successfully!";
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        [HttpPost]
        public JsonResult DeleteRecord(int id)
        {
            var publisher = db.Publishers.Find(id);
            db.Publishers.Remove(publisher);
            var result = db.SaveChanges();
            if (result > 0)
            {
                TempData["result"] = "Delete publisher successfully!";
                return Json(new { success = true });
            }
            else
            {
                TempData["result"] = "Delete publisher failed!";
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
        //        TempData["result"] = "Delete publisher successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["result"] = "Delete publisher failed sucefully!";
        //    return HttpNotFound();
        //}


        public ActionResult ViewDetail(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            return View(publisher);
        }

        public ActionResult Create()
        {
            Publisher publisher = new Publisher();
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publisher publisher, HttpPostedFileBase upload_image)
        {

            if (ModelState.IsValid)
            {
                //if (upload_image != null && upload_image.ContentLength > 0)
                //{
                //    int id = int.Parse(db.Publishers.ToList().Last().id.ToString());
                //    string _FileName = "";
                //    int index = upload_image.FileName.IndexOf('.');
                //    _FileName = "publisher" + id.ToString() + '.' + upload_image.FileName.Substring(index + 1);
                //    string _path = Path.Combine(Server.MapPath("~/images/publisher"), _FileName);

                //    upload_image.SaveAs(_path);



                //    Publisher a = db.Publishers.FirstOrDefault(x => x.id == id);
                //    a.image = _FileName;

                //    db.SaveChanges();
                //    TempData["result"] = "Create new publisher successfully!";
                //}
                db.Publishers.Add(publisher);
                db.SaveChanges();
                TempData["result"] = "Create new publisher successfully!";
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(publisher);
        }

    }
}