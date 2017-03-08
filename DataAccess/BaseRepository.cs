using Domain;
using Domain.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : IdHolder
    {
        private readonly Dictionary<int, T> _dictionary = new Dictionary<int, T>();

        public void Add(T item)
        {
            _dictionary.Add(item.Id,item);
        }

        public void AddOrUpdate(T item)
        {
            if (_dictionary.ContainsKey(item.Id))
                Update(item);
            else
                Add(item);
        }

        public T[] GetAll()
        {
            return _dictionary.Values.ToArray();
        }

        public T[] GetMany(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return _dictionary.Remove(item.Id);
        }

        public void Update(T item)
        {
            _dictionary[item.Id] = item;
        }
    }
}
