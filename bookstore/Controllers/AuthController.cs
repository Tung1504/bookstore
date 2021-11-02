using bookstore.DAO;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels.Auth;
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
        public ActionResult SignUp(LoginSignUpViewModel loginSignUpViewModel, UserDAO userDAO)
        {
            if (ModelState.IsValid)
            {
                if (userDAO.Any(x => x.username == loginSignUpViewModel.SignupViewModel.Username))
                {
                    SetErrorFlash("Account exists", "signup-fail");
                    return RedirectToAction("LoginOrSignup");
                }
                else
                {
                    User u = new User()
                    {
                        username = loginSignUpViewModel.SignupViewModel.Username,
                        password = loginSignUpViewModel.SignupViewModel.Password,
                        name = loginSignUpViewModel.SignupViewModel.Name,
                        phone = loginSignUpViewModel.SignupViewModel.Phone,
                        email = loginSignUpViewModel.SignupViewModel.Email,
                        dob = loginSignUpViewModel.SignupViewModel.Dob,
                        role = Models.User.CUSTOMER
                    };

                    userDAO.Create(u);
                    AuthUser.SetLogin(u);

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
        public ActionResult Login(LoginSignUpViewModel LoginSignupViewModel, UserDAO userDAO)
        {
            if (ModelState.IsValid)
            {
                User u = userDAO.FirstOrDefault(p => p.username == LoginSignupViewModel.LoginViewModel.Username &&
                p.password == LoginSignupViewModel.LoginViewModel.Password);
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
                        //return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        SetErrorFlash("Wrong UserName or Password", "login-failed");
                    }
                }
                else
                {
                    SetErrorFlash("Wrong UserName or Password", "login-failed");
                }

            }

            return View("LoginOrSignUp");
        }
    }

}