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
    }
}