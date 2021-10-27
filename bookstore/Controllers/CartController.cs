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
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;

            return View(cart);
        }
        public RedirectToRouteResult AddToCart(int bookId)
        {
            if (AuthUser.GetLogin() != null)
            {
                if (Session["cart"] == null)
                {
                    Session["cart"] = new List<CartItem>();
                }

                List<CartItem> cart = Session["cart"] as List<CartItem>;
                if (cart.FirstOrDefault(m => m.Book.id == bookId) == null)
                {
                    Book book = db.Books.Find(bookId);
                    CartItem newItem = new CartItem(book, 1);
                    cart.Add(newItem);
                }
                else
                {
                    CartItem cartItem = cart.FirstOrDefault(m => m.Book.id == bookId);
                    cartItem.Quantity++;
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginOrSignup", "Home");
            }
        }
        public RedirectToRouteResult UpdateQuantity(int bookId, int quantity)
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem updateItem = cart.FirstOrDefault(m => m.Book.id == bookId);
            if (updateItem != null)
            {
                if (updateItem.Book.quantity_in_stock >= quantity)
                {
                    updateItem.Quantity = quantity;
                }
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult DeleteFromCart(int bookId)
        {
            List<CartItem> giohang = Session["cart"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.Book.id == bookId);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            User user = AuthUser.GetLogin();
            // Fetch the userprofile

            List<Address> AddressList= db.Addresses.Where(m => m.user_id == user.id).ToList();
            List<Payment_card> PaymentList = db.Payment_card.Where(m => m.user_id == user.id).ToList();
            AddressAndPayment addressAndPayment = new AddressAndPayment();
            UserPaymentListAndAddressListViewModels paymentListAndAddressListViewModels = new UserPaymentListAndAddressListViewModels(user,AddressList, PaymentList,addressAndPayment);
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
               
                int orderNo = db.Orders.Count()+1;
                
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

               double total_price = cart.Sum(x=> x.Linetotal);
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
                foreach(var item in cart)
                {
                    db.Order_Detail.Add(new Order_Detail
                    {
                        book_id = item.Book.id,
                        order_id = order.id,
                        quantity = item.Quantity,
                        total_price =(int) item.Linetotal
                        
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
