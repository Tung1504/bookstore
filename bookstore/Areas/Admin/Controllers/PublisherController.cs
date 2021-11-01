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
using bookstore.Areas.Admin.ViewModels.Publisher;
using bookstore.Services;

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
            CreatePublisherViewModel publisherViewModel = new CreatePublisherViewModel();
            return View(publisherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePublisherViewModel createPublisherViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {                
                Publisher publisher = new Publisher(createPublisherViewModel.PublisherName, createPublisherViewModel.PubliserDescription, 
                    createPublisherViewModel.EstDate, image.FileName);
                publisherDAO.Create(publisher);
                UploadService.Upload(image, UploadService.PUBLISHER_AVATAR_PATH);
                SetSuccessFlash("Create new publisher successfully!");
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(createPublisherViewModel);
        }

    }
}