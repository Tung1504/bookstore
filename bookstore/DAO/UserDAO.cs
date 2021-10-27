using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class UserDAO : BaseDAO<User>
    {
        public UserDAO()
        {
            dbSet = db.Users;
        }
    }
}