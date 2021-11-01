using bookstore.DAO;
using bookstore.Filters.AuthorFilters;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    [Authenticated]
    public class CustomerController : BaseController
    {
        UserDAO UserDAO;

        public CustomerController(UserDAO userDAO)
        {
            UserDAO = userDAO;
        }

        public ActionResult Index()
        {
            User user = AuthUser.GetLogin();
            return View(user);
        }

        [HttpGet]
        public ActionResult UpdateInformation()
        {
            int authId = AuthUser.GetLogin().id;
            User u = UserDAO.FirstOrDefault(p => p.id == authId);
            CustomerUpdateInformationViewModel customerUpdateInformationViewModel = new CustomerUpdateInformationViewModel()
            {
                Username = u.username,
                Phone = u.phone,
                Name = u.name,
                Dob = u.dob,
                Email = u.email
            };
            return View(customerUpdateInformationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInformation(CustomerUpdateInformationViewModel customerUpdateInformationViewModel)
        {
            if (ModelState.IsValid)
            {

                User user = new User()
                {
                    name = customerUpdateInformationViewModel.Name,
                    username = customerUpdateInformationViewModel.Username,
                    email = customerUpdateInformationViewModel.Email,
                    dob = customerUpdateInformationViewModel.Dob,
                    phone = customerUpdateInformationViewModel.Phone,
                    role = AuthUser.GetLogin().role,
                    id = AuthUser.GetLogin().id,
                    password = AuthUser.GetLogin().password
                };


                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                AuthUser.SetLogin(user);
                return RedirectToAction("Index");
            }

            return View(customerUpdateInformationViewModel);
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(CustomerResetPasswordViewModel customerResetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {

                User user = new User()
                {
                    name = AuthUser.GetLogin().name,
                    username = AuthUser.GetLogin().username,
                    email = AuthUser.GetLogin().email,
                    dob = AuthUser.GetLogin().dob,
                    phone = AuthUser.GetLogin().phone,
                    role = AuthUser.GetLogin().role,
                    id = AuthUser.GetLogin().id,
                    password = customerResetPasswordViewModel.Password
                };


                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                AuthUser.SetLogin(user);
                return RedirectToAction("Index");
            }

            return View(customerResetPasswordViewModel);
        }


    }
}