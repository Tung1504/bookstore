using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class PublisherDAO : BaseDAO<Publisher>
    {
        public PublisherDAO()
        {
            dbSet = db.Publishers;
        }
    }
}