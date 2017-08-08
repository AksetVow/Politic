using MongoDB.Driver;
using System;
using System.Configuration;

namespace DataAccess.Mongo
{
    public class MongoContext<T> where T : class
    {
        private readonly string _connectionString;

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        internal MongoContext(string connectionStringName)
        {
            if (connectionStringName == null)
                throw new ArgumentNullException(nameof(connectionStringName));
            _collectionName = typeof(T).Name;

            _connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _client = new MongoClient(_connectionString);
            _database = _client.GetDatabase(DatabaseName);
        }

        private string DatabaseName => new MongoUrl(_connectionString).DatabaseName;

        internal IMongoCollection<T> Collection => _database.GetCollection<T>(_collectionName);
    }
}
