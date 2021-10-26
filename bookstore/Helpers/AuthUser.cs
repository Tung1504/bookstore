using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Helpers
{
    public class AuthUser
    {
        public static void SetLogin(User u)
        {
            HttpContext.Current.Session["auth"] = u;
        }

        public static string Username()
        {
            User u = (User)HttpContext.Current.Session["auth"];
            return u.name;
        }

        public static int Id()
        {
            User u = (User)HttpContext.Current.Session["auth"];
            return u.id;
        }
    }
}