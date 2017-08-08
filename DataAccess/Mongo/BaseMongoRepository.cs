using MongoDB.Driver;
using System;
using System.Configuration;

namespace DataAccess.Mongo
{
    public class BaseMongoRepository<T>
    {
        protected IMongoCollection<T> _collection;
        internal BaseMongoRepository(string connectionStringName)
        {
            if (connectionStringName == null)
                throw new ArgumentNullException(nameof(connectionStringName));
            _collection = GetCollection(connectionStringName);
        }

        private IMongoCollection<T> GetCollection(string connectionStringName)
        {
            var collectionName = typeof(T).Name;

            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            var databaseName = new MongoUrl(connectionString).DatabaseName;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            var collection = database.GetCollection<T>(collectionName);
            return collection;
        }

        protected T[] GetAll()
        {
            var result = AsyncHelper.RunAsync(() => _collection.Find(x => true).ToListAsync());

            return result.ToArray();
        }

        protected T[] Get(Func<T, bool> predicate)
        {
            var result = AsyncHelper.RunAsync(() => _collection.Find(x => predicate(x)).ToListAsync());

            return result.ToArray();
        }

        protected void Add(T item)
        {
            _collection.InsertOne(item);
        }

        protected bool Remove(Func<T, bool> predicate)
        {
            var result = _collection.DeleteMany(x => predicate(x));
            return result.DeletedCount > 0;
        }

        protected void Update(T item, Func<T, bool> predicate)
        {
            _collection.ReplaceOne(x => predicate(x), item);
        }


    }
}
