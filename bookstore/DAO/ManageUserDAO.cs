using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookstore.Models;
using bookstore.ViewModels;

namespace bookstore.DAO
{
    public class ManageUserDAO
    {
        //protected BookStoreEntities db = new BookStoreEntities();
        //public UserViewModel User(int id)
        //{
        //    var model = from u in db.Users
        //                join a in db.Addresses on u.id equals a.user_id
        //                join p in db.Payment_card on u.id equals p.user_id
        //                where a.user_id == id
        //                select new UserViewModel()
        //                {
        //                    Name = u.name,
        //                    Username = u.username,
        //                    Role = u.role,
        //                    Phone = u.phone,
        //                    Email = u.email,
        //                    Dob = u.dob,
        //                    Address = a.address1,
        //                    City = a.city,
        //                    District = a.district,
        //                    PostalCode = a.postal_code,
        //                    CardNumber = p.card_number,
        //                    CardType = p.card_type,
        //                    FromDate = p.from_date,
        //                    ToDate = p.to_date
        //                };
        //    return model;
        //}
    }
}