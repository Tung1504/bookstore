using bookstore.DAO;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels.Auth;
using bookstore.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        protected BookStoreEntities db = new BookStoreEntities();

        protected void SetErrorFlash(string message, string key = "error")
        {
            TempData[key] = message;
        }

        protected void SetSuccessFlash(string message, string key = "error")
        {
            TempData[key] = message;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("");
        }


        [HttpPost]
        public ActionResult Login(LoginSignUpViewModel LoginSignupViewModel, UserDAO userDAO)
        {
            if (ModelState.IsValid)
            {
                User u = userDAO.FirstOrDefault(p => p.username == LoginSignupViewModel.LoginViewModel.Username &&
                                                        p.password == LoginSignupViewModel.LoginViewModel.Password);

                if (u != null)
                {
                   
                    AuthUser.SetLogin(u);

                    if (u.role == Models.User.ADMIN)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    if (u.role != Models.User.ADMIN)
                    {
                        //return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        SetErrorFlash("Wrong UserName and Password", "login-failed");
                    }

                }
                else
                {
                    SetErrorFlash("Wrong UserName or Password", "login-failed");
                }

            }

            return View("Index");
        }


        //[HttpGet]
        //public ActionResult ResetPassword()
        //{

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(CustomerResetPasswordViewModel customerResetPasswordViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        User user = new User()
        //        {
        //            name = AuthUser.GetLogin().name,
        //            username = AuthUser.GetLogin().username,
        //            email = AuthUser.GetLogin().email,
        //            dob = AuthUser.GetLogin().dob,
        //            phone = AuthUser.GetLogin().phone,
        //            role = AuthUser.GetLogin().role,
        //            id = AuthUser.GetLogin().id,
        //            password = customerResetPasswordViewModel.Password
        //        };


        //        db.Entry(user).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //        SetSuccessFlash("");
        //        AuthUser.SetLogin(user);
        //        return RedirectToAction("Index");
        //    }

        //    return View(customerResetPasswordViewModel);
        //}

    }
}