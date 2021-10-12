using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class BaseController : Controller
    {
        protected BookStoreEntities db = new BookStoreEntities();
    }
}