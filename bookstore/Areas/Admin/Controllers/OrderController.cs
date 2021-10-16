using bookstore.Models;
using bookstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/ManageOrder
        public ActionResult Index()
        {
            List<Order> order = db.Orders.ToList();
            return View();
        }


        public ActionResult ViewDetail(int id)
        {
           
            List<Order_Detail> listOrderDetials = db.Order_Detail.ToList();

            Order order = db.Orders.Find(id);
            Order_Detail order_Detail = listOrderDetials.Find(i => i.order_id == id);

            OrderViewModel orderViewModel = new OrderViewModel(order, order_Detail);
            return View(orderViewModel);
        }
    }
}