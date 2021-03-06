﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Datastore.Contracts
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}