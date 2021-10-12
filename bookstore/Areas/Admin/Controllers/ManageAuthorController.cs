using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class ManageAuthorController : BaseController
    {
        // GET: Admin/ManageAuthor
        public ActionResult Index()
        {
            return View();
        }
    }
}