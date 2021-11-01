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
                int id = AuthUser.GetLogin().id;
                List<CartItem> cart = Session["cart"] as List<CartItem>;
                if (cart.FirstOrDefault(m => m.Book.id == bookId) == null)
                {
                    Book book = db.Books.Find(bookId);
                    CartItem newItem = new CartItem(book, 1, id);
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
                return RedirectToAction("LoginOrSignup", "Auth");
            }
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int bookId, int quantity)
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem updateItem = cart.FirstOrDefault(m => m.Book.id == bookId);
            if (updateItem != null)
            {
                if (updateItem.Book.quantity_in_stock >= quantity)
                {
                    updateItem.Quantity = quantity;
                }
                else
                {
                    TempData["Message"] = "quantity is greater than quantity in stock";
                }
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult DeleteFromCart(int bookId)
        {
            List<CartItem> giohang = Session["cart"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.Book.id == bookId);
            if (itemXoa != null && itemXoa.UserId == AuthUser.GetLogin().id)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            User user = (User)Session["auth"];
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
            if (ModelState.IsValid)
            {
                int n;
                string city;
                bool isNumeric = int.TryParse(model.Address, out n);
                if (isNumeric)
                {
                    n = int.Parse(model.Address);
                    Address address = db.Addresses.Find(n);
                    city = address.address1 + " " + address.city + " " + address.district + " " + address.postal_code;
                }
                else
                {
                    city = model.Address;
                }
                List<CartItem> cart = Session["cart"] as List<CartItem>;
                User user = (User)Session["auth"];

                int orderNo = db.Orders.Count() + 1;
                string orderNumber = "1000" + orderNo;
                int shipping_price;

                shipping_price = 2;


                string status = "Pending";
                string payment_status;
                if (!model.Payment.Equals("COD (Cash on delivery)"))
                {
                    payment_status = "Paid";
                }
                else
                {
                    payment_status = "Unpaid";
                }
                string note = model.Note;
                double total_price = cart.Sum(x => x.Linetotal) + shipping_price;
                int user_id = user.id;
                DateTime date = DateTime.Now;
                Order order = new Order
                {
                    order_number = Int32.Parse(orderNumber),
                    shipping_price = shipping_price,
                    status = status,
                    payment_status = payment_status,
                    total_price = total_price,
                    user_id = user_id,
                    date = date,
                    delivery_location = city,
                    note = note
                };
                db.Orders.Add(order);
                foreach (var item in cart)
                {
                    if (item.UserId == AuthUser.GetLogin().id)
                    {
                        db.Order_Detail.Add(new Order_Detail
                        {
                            book_id = item.Book.id,
                            order_id = order.id,
                            quantity = item.Quantity,
                            total_price = (int)item.Linetotal

                        });


                    }
                }
                foreach (var item in cart)
                {
                    if (item.UserId == AuthUser.GetLogin().id)
                    {

                        Book book = db.Books.FirstOrDefault(p => p.id == item.Book.id);
                        book.quantity_in_stock = book.quantity_in_stock - item.Quantity;

                    }
                }
                cart.RemoveAll(x => x.UserId == AuthUser.GetLogin().id);
                Session["Cart"] = cart;


                db.SaveChanges();
                return RedirectToAction("Index","UserOrder");
            }
            else
            {
                User user = (User)Session["auth"];
                List<Address> AddressList = db.Addresses.Where(m => m.user_id == user.id).ToList();
                List<Payment_card> PaymentList = db.Payment_card.Where(m => m.user_id == user.id).ToList();
                AddressAndPayment addressAndPayment = new AddressAndPayment();
                UserPaymentListAndAddressListViewModels paymentListAndAddressListViewModels = new UserPaymentListAndAddressListViewModels(user, AddressList, PaymentList, addressAndPayment);
                return View(paymentListAndAddressListViewModels);
            }
        
        }
        //public ActionResult PurchasedSuccess()
        //{
            
        //}

    }
}