using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["auth"] != null) {
                User user = (User)Session["auth"];

                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            
        }
        public ActionResult UpdateInformation()
        {
            User u = (User)Session["auth"];
          
            return View(u);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInformation(int userId,User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }
    }
}