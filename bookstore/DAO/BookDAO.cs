using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class BookDAO : BaseDAO<Book>
    {
        public BookDAO()
        {
            dbSet = db.Books;
        }
    }
}