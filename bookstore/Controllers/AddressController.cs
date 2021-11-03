﻿using bookstore.Filters.AuthorFilters;
using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    [Authenticated]
    public class AddressController : BaseController
    {
        // GET: Address
        public ActionResult Index()
        {
            int user_id = Convert.ToInt32(AuthUser.GetLogin().id);

            List<Address> listAddress = db.Addresses.Where(a => a.user_id == user_id).ToList();

            return View(listAddress);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {

            if (ModelState.IsValid)
            {
                int user_id = Convert.ToInt32(AuthUser.GetLogin().id);
                address.user_id = user_id;
                db.Addresses.Add(address);
                db.SaveChanges(); //Apply insert statement
                SetSuccessFlash("Create new address successfully!");
                return RedirectToAction("Index");
            }

            //nếu validate thất bại
            return View(address);
        }

        public ActionResult Edit(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Address address)
        {
            if (ModelState.IsValid)
            {
                int user_id = Convert.ToInt32(AuthUser.GetLogin().id);
                address.user_id = user_id;
                db.Entry(address).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                SetSuccessFlash("Edit address successfully!");
                return RedirectToAction("Index");
            }

            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address != null)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
                SetSuccessFlash("Delete address successfully!");
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }


    }
}