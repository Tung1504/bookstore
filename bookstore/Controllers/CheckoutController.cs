using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class CheckoutController : BaseController
    {
        public ActionResult Checkout()
        {
            User user = AuthUser.GetLogin();
            // Fetch the userprofile

            List<Address> AddressList = db.Addresses.Where(m => m.user_id == user.id).ToList();
            List<Payment_card> PaymentList = db.Payment_card.Where(m => m.user_id == user.id).ToList();
            AddressAndPayment addressAndPayment = new AddressAndPayment();
            UserPaymentListAndAddressListViewModels paymentListAndAddressListViewModels = new UserPaymentListAndAddressListViewModels(user, AddressList, PaymentList, addressAndPayment);
            return View(paymentListAndAddressListViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(UserPaymentListAndAddressListViewModels model)
        {
            User user = AuthUser.GetLogin();
            if (ModelState.IsValid)
            {
                List<CartItem> cart = Session["cart"] as List<CartItem>;

                int orderNo = db.Orders.Count() + 1;

                int shipping_price = 15000;

                string status = "Preparing";
                string payment_status;
                if (model.Payment != null)
                {
                    payment_status = "Paid";
                }
                else
                {
                    payment_status = "Unpaid";
                }

                double total_price = cart.Sum(x => x.Linetotal);
                int user_id = user.id;
                DateTime date = DateTime.Now;
                Order order = new Order
                {
                    order_number = orderNo,
                    shipping_price = shipping_price,
                    status = status,
                    payment_status = payment_status,
                    total_price = total_price,
                    user_id = user_id,
                    date = date
                };
                db.Orders.Add(order);
                foreach (var item in cart)
                {
                    db.Order_Detail.Add(new Order_Detail
                    {
                        book_id = item.Book.id,
                        order_id = order.id,
                        quantity = item.Quantity,
                        total_price = (int)item.Linetotal

                    });
                }
                Session["cart"] = new List<CartItem>();
                cart.Clear();
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Checkout");
            }

        }
    }
}