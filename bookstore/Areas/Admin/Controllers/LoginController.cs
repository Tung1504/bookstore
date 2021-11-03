using bookstore.DAO;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {

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
                    if (u.role == Models.User.CUSTOMER)
                    {
                        //return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        SetErrorFlash("Please input your admin account", "login-failed");
                    }

                }
                else
                {
                    SetErrorFlash("Wrong UserName or Password", "login-failed");
                }

            }

            return View("Index");
        }


    }
}