using bookstore.Models;
using bookstore.ViewModels;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges(); //Apply insert statement
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(user);
        }


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
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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
                        TempData["result"] = "Edit category successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        db.Users.Remove(user);
                        db.Addresses.Remove(address);
                        db.SaveChanges();
                        TempData["result"] = "Edit category successfully!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    TempData["result"] = "Edit category successfully!";
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }
    }
}