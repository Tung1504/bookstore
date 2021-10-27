﻿using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<T> Where(Expression<Func<T,bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return dbSet.Any(expression);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
            SaveChanges();
        }   
        
        public T FirstOrDefault(Expression<Func<T,bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}