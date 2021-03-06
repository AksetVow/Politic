﻿using System;
using System.Linq.Expressions;

namespace Domain.DataAccess
{
    public interface IRepository<T> where T: IdHolder
    {
        T[] GetAll();

        T[] GetMany(Expression<Func<T, bool>> filter);

        bool Remove(T item);

        void Add(T Item);

        void Update(T item);

        void AddOrUpdate(T item);
    }
}
