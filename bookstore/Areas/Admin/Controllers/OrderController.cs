﻿using bookstore.Controllers;
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
            return View(order);
        }


        public ActionResult ViewDetail(int id)
        {
            List<Order_Detail> listOrderDetails = db.Order_Detail.ToList();
            List<User> listUser = db.Users.ToList();
            List<Address> listArress = db.Addresses.ToList();
            List<Payment_card> listPayment = db.Payment_card.ToList();

            Order order = db.Orders.Find(id);
            Order_Detail order_Detail = listOrderDetails.Find(i => i.Order.id == id);
            User user = listUser.Find(i => i.id == order.user_id);
            Address address = listArress.Find(i => i.user_id == user.id);
            Payment_card payment_Card = listPayment.Find(i => i.user_id == user.id);

            OrderViewModel orderViewModel = new OrderViewModel(order, order_Detail, user, address, payment_Card, listOrderDetails);
            return View(orderViewModel);
        }

        public ActionResult Edit(int id)
        {
            List<Order_Detail> listOrderDetails = db.Order_Detail.ToList();
            List<User> listUser = db.Users.ToList();
            List<Address> listArress = db.Addresses.ToList();
            List<Payment_card> listPayment = db.Payment_card.ToList();

            Order order = db.Orders.Find(id);
            Order_Detail order_Detail = listOrderDetails.Find(i => i.Order.id == id);
            User user = listUser.Find(i => i.id == order.user_id);
            Address address = listArress.Find(i => i.user_id == user.id);
            Payment_card payment_Card = listPayment.Find(i => i.user_id == user.id);

            OrderViewModel orderViewModel = new OrderViewModel(order, order_Detail, user, address, payment_Card, listOrderDetails);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(orderViewModel).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewDetail");
            }

            return View(orderViewModel);
        }
    }
}