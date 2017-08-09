using Domain;
using Domain.DataAccess;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Mongo
{
    public class MongoDeputyRepository : BaseMongoRepository<Deputy>, IDeputyRepository
    {
        public MongoDeputyRepository(string connectionStringName) : base(connectionStringName)
        {
        }

        public void AddOrUpdate(Deputy item)
        {
            var deputy = Get(x => x.Id == item.Id).FirstOrDefault();
            if (deputy == null)
                Add(item);
            else
                Update(item);
        }

        public Deputy[] GetMany(Expression<Func<Deputy, bool>> filter)
        {
            return Get(filter);
        }

        public bool Remove(Deputy item)
        {
            return Remove(x => x.Id == item.Id);
        }

        public void Update(Deputy item)
        {
            Update(item, x => x.Id == item.Id);
        }

        void IRepository<Deputy>.Add(Deputy item)
        {
            Add(item);
        }

        Deputy[] IRepository<Deputy>.GetAll()
        {
            return GetAll();
        }
    }
}
