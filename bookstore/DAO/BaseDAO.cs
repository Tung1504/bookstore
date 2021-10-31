using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class BaseDAO<T> where T : class
    {
        protected BookStoreEntities db = new BookStoreEntities();

        protected DbSet<T> dbSet;

        public List<T> All()
        {
            return dbSet.Select(x => x).ToList();
        }
    }
}