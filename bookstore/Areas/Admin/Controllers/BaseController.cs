using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected BookStoreEntities db = new BookStoreEntities();

        public ActionResult AuthencatedByRole()
        {
            if (AuthUser.GetLogin().role.ToString() == "Customer")
            {
                return RedirectToAction("LoginOrSignUp", "Auth", new { area = "" });
            }
            else
            {
                return null;

            }
        }
    }
}
