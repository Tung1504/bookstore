using bookstore.Helpers;
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
            if (AuthUser.GetLogin() != null) {
                User user = AuthUser.GetLogin();
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult UpdateInformation()
        {
            User u = AuthUser.GetLogin();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInformation([Bind(Exclude ="password")]User user)
        {
            ModelState.Remove("password");
            ModelState.Remove("repassword");

            if (ModelState.IsValid)
            {
                //user.password = AuthUser.GetLogin().password;
                //user.role = AuthUser.GetLogin().role;
                //user.repassword = user.password;
                //user.dob = user.dob.Date;
                //db.Entry(user).State = System.Data.EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            
            return View(user);
        }
    }
}