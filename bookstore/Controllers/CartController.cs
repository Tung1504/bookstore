using bookstore.DAO;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.ViewModels.Cart;
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
        public ActionResult Index(CartHelper cartHelper)
        {
            List<CartItem> cart = cartHelper.GetProductsInCart();
            CartViewModel cartViewModel = new CartViewModel(cart);
            return View(cartViewModel);
        }

        public RedirectToRouteResult AddToCart(int bookId, CartHelper cartHelper)
        {
            if (AuthUser.GetLogin() != null)
            {
                cartHelper.AddProductToCart(bookId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginOrSignup", "Auth");
            }
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int id, CartViewModel cartViewModel, CartHelper cartHelper)
        {
            cartHelper.UpdateQuantity(id, cartViewModel.Quantity);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int bookId, CartHelper cartHelper)
        {
            cartHelper.DeleteCartItem(bookId);
            return RedirectToAction("Index");
        }       
    }
}
