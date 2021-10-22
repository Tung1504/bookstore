using bookstore.Models;
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
            if ((User)Session["auth"] != null)
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
            CartItem itemXoa = giohang.FirstOrDefault(m => m.Book.id == bookId );
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
           
        }
    }
