using bookstore.DAO;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        

        // GET: Admin/ManageUser
        public ActionResult Index()
        {
            List<User> listUser = db.Users.ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(listUser);
        }


        public ActionResult AdminView()
        {
            List<User> listUser = db.Users.Where(m => m.role == "Admin").ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(listUser);
        }

        public ActionResult UserView()
        {
            List<User> listUser = db.Users.Where(m => m.role == "Customer").ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(listUser);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginSignUpViewModel loginSignUpViewModel, UserDAO userDAO)
        {
            if (ModelState.IsValid)
            {
                if (userDAO.Any(x => x.username == loginSignUpViewModel.SignupViewModel.Username))
                {
                    ViewBag.CreateFail = "This name has been accounted";
                    return View();
                }
                else
                {
                    if (userDAO.Any(x => x.email == loginSignUpViewModel.SignupViewModel.Email))
                    {
                        ViewBag.CreateFail = "This email has been accounted";
                        return View();
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
                            role = loginSignUpViewModel.SignupViewModel.Role
                        };
                        userDAO.Create(u);
                        TempData["result"] = "Create new user successfully!";
                        return RedirectToAction("AdminView");
                    }
                }
            }

            return View(loginSignUpViewModel);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(User user)
        //{
        //    if (db.Users.Any(x => x.username == user.username))
        //    {
        //        ViewBag.CreateFail = "This name has been accounted";
        //        return View();
        //    }
        //    else
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Users.Add(user);
        //            db.SaveChanges(); //Apply insert statement
        //            TempData["result"] = "Create new user successfully!";
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    nếu validate thất bại
        //    return View(user);
        //}


        public ActionResult ViewDetail(int id)
        {
            List<Address> listAddress = db.Addresses.ToList();
            List<Payment_card> listPayments = db.Payment_card.ToList();

            User user = db.Users.Find(id);
            Address address = listAddress.Find(i => i.user_id == id);
            Payment_card paymentCard = listPayments.Find(i => i.user_id == id);

            UserAddressPaymentCardViewModels userAddressPaymentCardViewModels = new UserAddressPaymentCardViewModels(user, address, paymentCard);
            return View(userAddressPaymentCardViewModels);
        }

        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            User u = db.Users.FirstOrDefault(x => x.id == id);
            if (u != null)
            {
                if(u.role == "Admin")
                {
                    user.role = "Customer";
                }
                else if (u.role == "Customer")
                {
                    user.role = "Admin";
                }
                
                db.SaveChanges();
                TempData["result"] = "Update user " + user.username + " role successfully!";
                return RedirectToAction("Index");

            }
            TempData["result"] = "Update user " + user.username + " role failed successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            List<Address> listAddress = db.Addresses.ToList();
            List<Payment_card> listPayments = db.Payment_card.ToList();

            User user = db.Users.Find(id);
            Address address = listAddress.Find(i => i.user_id == id);
            Payment_card paymentCard = listPayments.Find(i => i.user_id == id);

            if (user != null)
            {
                if (address != null)
                {
                    if (paymentCard != null)
                    {
                        db.Users.Remove(user);
                        db.Addresses.Remove(address);
                        db.Payment_card.Remove(paymentCard);
                        db.SaveChanges();
                        //TempData["result"] = "Edit user successfully!";
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Users.Remove(user);
                        db.Addresses.Remove(address);
                        db.SaveChanges();
                        //TempData["result"] = "Edit user successfully!";
                        return Json(new { success = true });
                    }
                }
                else
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    TempData["result"] = "Delete user successfully!";
                    return Json(new { success = true });
                }

            }
            TempData["result"] = "Delete user failed successfully!";
            return Json(new { success = false });
        }
    }
}