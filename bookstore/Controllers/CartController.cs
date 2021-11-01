using bookstore.Filters.AuthorizeFilters;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels.Cart;
using bookstore.ViewModels.ProductDetailViewModel;
using System.Collections.Generic;

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

        [Authenticated]
        public ActionResult AddToCart(int bookId, ProductDetailViewModel productDetailViewModel, CartHelper cartHelper)
        {
            cartHelper.AddProductToCart(bookId, productDetailViewModel.Quantity);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authenticated]
        public ActionResult UpdateQuantity(int bookId, CartViewModel cartViewModel, CartHelper cartHelper)
        {
            bool isUpdated = cartHelper.UpdateQuantity(bookId, cartViewModel.Quantity);
            if (!isUpdated)
            {
                SetErrorFlash(string.Format("Quantity of cart item is greater than in stock"));
            }
            return RedirectToAction("Index");
        }
        
        [Authenticated]
        public ActionResult DeleteFromCart(int bookId, CartHelper cartHelper)
        {
            cartHelper.DeleteCartItem(bookId);
            return RedirectToAction("Index");
        }       
    }
}
