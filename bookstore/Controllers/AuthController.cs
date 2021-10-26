using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.username != user.username))
                {
                    SetErrorFlash("Account exists", "signup-fail");
                    return RedirectToAction("LoginOrSignup");
                }
                else
                {
                    user.role = Models.User.CUSTOMER;
                    db.Users.Add(user);
                    db.SaveChanges();
                    AuthUser.SetLogin(user);

                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View("~/Views/Auth/LoginOrSignUp.cshtml");
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult LoginOrSignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User u = db.Users.FirstOrDefault(p => p.username == user.username && p.password == user.password);
            if (u != null)
            {
                // Login: goc man hinh: camnh
                AuthUser.SetLogin(u);

                if (u.role == Models.User.CUSTOMER)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (u.role == Models.User.ADMIN)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                }
            }
            else
            {
                SetErrorFlash("Wrong UserName or Password", "login-failed");
            }

            return RedirectToAction("LoginOrSignup");
        }
    }
}