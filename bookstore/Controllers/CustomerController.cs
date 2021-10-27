using bookstore.Models;
using bookstore.ViewModels;
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
            if (Session["auth"] != null)
            {
                User user = (User)Session["auth"];

                return View(user);
            }
            else
            {
                return RedirectToAction("LoginOrSignUp", "Home");
            }


        }

        public ActionResult UpdateInformation()
        {
            User u = (User)Session["auth"];

            return View(u);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInformation(User user)
        {
            ModelState.Remove("repassword");
            if (ModelState.IsValid)
            {
                User u = (User)Session["auth"];
                user.password = u.password;
                user.repassword = u.password;
                user.role = u.role;
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                Session["auth"] = user;
                return RedirectToAction("Index");
            }

            return View(user);
        }


        //#TODO: Use UserViewModel instead of User
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdateInformation(UserViewModel uvm)
        //{

        //    User u = (User)Session["auth"];
        //    if (ModelState.IsValid)
        //    {
        //        u.name = uvm.name;
        //        u.username = uvm.username;
        //        u.phone = uvm.phone;
        //        u.email = uvm.email;
        //        db.Entry(u).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //        Session["auth"] = u;
        //        return RedirectToAction("Index");
        //    }

        //    return View(u);
        //}



    }
}