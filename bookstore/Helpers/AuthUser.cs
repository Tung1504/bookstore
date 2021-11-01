using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Helpers
{
    public class AuthUser
    {
        public static void SetLogin(User u)
        {
            HttpContext.Current.Session["auth"] = u;
        }
        public static User GetLogin()
        {
            if (HttpContext.Current.Session["auth"] != null)
            {
                return (User)HttpContext.Current.Session["auth"];
            }
            else
                return null;
        }
    }
}