using bookstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class BaseController : Controller
    {
        protected BookStoreEntities db = new BookStoreEntities();

        public void print(string s)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\viet\Desktop\DotNet project\test\out.txt", true))
            {
                writer.WriteLine(s);
            }
        }

        protected void SetErrorFlash(string message, string key = "error")
        {
            TempData[key] = message;
        }

        protected void SetSuccessFlash(string message, string key = "success")
        {
            TempData[key] = message;
        }
    }
}