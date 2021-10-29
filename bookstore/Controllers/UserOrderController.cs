using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookstore.Helpers;
using bookstore.Models;
namespace bookstore.Controllers
{
    public class UserOrderController : BaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            int userId = AuthUser.GetLogin().id;
           var  orders = db.Orders.Where(o => o.user_id == userId).ToList();
            orders.OrderByDescending(o => o.order_number);
            List<Order> orderList = orders;
            return View(orderList);
        }

        public ActionResult Delete(int order_id)
        {
            Order order = db.Orders.FirstOrDefault(o=> o.id==order_id);
            if(order!=null && order.status == "Pending")
            {
                
                order.status = "Cancel";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult ViewDetails(int order_id)
        {

            Order order = db.Orders.FirstOrDefault(p => p.id == order_id);
            List<Order_Detail> order_Details = db.Order_Detail.Include(o=> o.Book).Where(o=> o.order_id== order_id).ToList();
            OrderDetailView orderDetailView = new OrderDetailView(order, order_Details);
            return View(orderDetailView);
        }
    }
}