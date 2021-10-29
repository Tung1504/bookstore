using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class AuthorDAO : BaseDAO<Author>
    {
        public AuthorDAO()
        {
            dbSet = db.Authors;
        }
    }
}