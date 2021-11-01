using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using bookstore.Extensions;
using System.IO;
using bookstore.DAO;
using bookstore.Controllers;

namespace bookstore.Areas.Admin.Controllers
{
    public class PublisherController : BaseController
    {
        PublisherDAO publisherDAO;

        public PublisherController(PublisherDAO publisherDAO)
        {
            this.publisherDAO = publisherDAO;
        }
        // GET: Admin/Managepublisher
        public ActionResult Index()
        {
            List<Publisher> publishers = publisherDAO.All();
            
            return View(publishers);
        }

        public ActionResult Edit(int id)
        {
            Publisher publisher = publisherDAO.Find(id);
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
                SetSuccessFlash("Edit publisher successfully!");
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Publisher publisher = publisherDAO.Find(id);
            if (publisher != null)
            {
                bool isDeleted = publisherDAO.Delete(publisher);
                if (isDeleted)
                {
                    SetSuccessFlash("Publisher deleted successfully");
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }

        public ActionResult ViewDetail(int id)
        {
            Publisher publisher = publisherDAO.Find(id);
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