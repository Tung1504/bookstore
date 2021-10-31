using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.DAO
{
    public class CategoryDAO : BaseDAO<Category>
    {
        public CategoryDAO()
        {
            dbSet = db.Categories;
        }
    }
}