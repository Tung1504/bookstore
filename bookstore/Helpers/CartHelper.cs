using bookstore.DAO;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Helpers
{
    public class CartHelper
    {
        List<CartItem> cartItems;

        BookDAO bookDAO = new BookDAO();

        public CartHelper()
        {
            cartItems = HttpContext.Current.Session["cart"] as List<CartItem>;
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
            }
        }

        public List<CartItem> GetProductsInCart()
        {
            return cartItems;
        }
        
        public int CountTotalItemsInCart()
        {
            return cartItems.Count;
        }

        public void AddProductToCart(int bookId, int quantity = 1)
        {
            CartItem existingCartItem = FindBookInCart(bookId);
            if (existingCartItem != null)
            {
                Book book = bookDAO.Find(bookId);
                existingCartItem.Quantity = quantity > book.quantity_in_stock - existingCartItem.Quantity ? 
                    book.quantity_in_stock : existingCartItem.Quantity + quantity;
            }
            else
            {
                Book book = bookDAO.Find(bookId);
                cartItems.Add(new CartItem(book, quantity));
            }
            RefreshCartSession();
        }

        public CartItem FindBookInCart(int bookId)
        {
            CartItem cartItem = cartItems.FirstOrDefault(p => p.Book.id == bookId);
            if (cartItem != null)
            {
                return cartItem;
            }

            return null;
        }

        public void DeleteCartItem(int bookId)
        {
            CartItem cartItem = cartItems.Find(p => p.Book.id == bookId);            
            if (cartItems.Remove(cartItem))
            {
                RefreshCartSession();
            }
        }

        public bool UpdateQuantity(int bookId, int quantity)
        { 
            Book book = bookDAO.Find(bookId);
            if (quantity <= book.quantity_in_stock)
            {
                CartItem cartItem = FindBookInCart(bookId);
                cartItem.Quantity = quantity;
                RefreshCartSession();
                return true;
            }

            return false;
            
        }

        public void RefreshCartSession()
        {
            HttpContext.Current.Session["cart"] = cartItems;
        }
    }
}