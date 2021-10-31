using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    // similar to AddressController
    public class PaymentCardController : BaseController 
    {
        // GET: Payment
        public ActionResult Index()
        {
            int user_id = Convert.ToInt32(AuthUser.GetLogin().id);

            List<Payment_card> listPaymentCard = db.Payment_card.Where(a => a.user_id == user_id).ToList();

            return View(listPaymentCard);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment_card paymentCard)
        {

            if (ModelState.IsValid)
            {
                int user_id = Convert.ToInt32(AuthUser.GetLogin().id);
                paymentCard.user_id = user_id;
                db.Payment_card.Add(paymentCard);
                db.SaveChanges(); //Apply insert statement
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(paymentCard);
        }

        public ActionResult Edit(int id)
        {
            Payment_card paymentCard = db.Payment_card.Find(id);
            if (paymentCard == null)
            {
                return HttpNotFound();
            }
            return View(paymentCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Payment_card paymentCard)
        {
            if (ModelState.IsValid)
            {
                int user_id = Convert.ToInt32(AuthUser.GetLogin().id);
                paymentCard.user_id = user_id;
                db.Entry(paymentCard).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Payment_card paymentCard = db.Payment_card.Find(id);
            if (paymentCard != null)
            {
                db.Payment_card.Remove(paymentCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}