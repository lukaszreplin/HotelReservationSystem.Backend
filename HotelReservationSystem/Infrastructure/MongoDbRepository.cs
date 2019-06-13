using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelReservationSystem.Infrastructure
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : class
    {
        public IMongoDatabase Database { get; }
        public MongoDbRepository(IMongoClient client)
        {
            Database = client.GetDatabase("hotelReservationDatabase");
        }
        public async Task InsertOne(T model)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(model);
        }

        public async Task InsertMany(IEnumerable<T> model)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            await collection.InsertManyAsync(model);
        }

        private static string GetCollectionName()
        {
            return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }

        public async Task<List<T>> GetAll()
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByCondition(FilterDefinition<T> filterDefinition)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            return await collection.Find(filterDefinition).SingleOrDefaultAsync();
        }

        public async Task Remove(FilterDefinition<T> filterDefinition)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            await collection.FindOneAndDeleteAsync(filterDefinition);
        }

        public async Task Edit(FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            await collection.FindOneAndUpdateAsync(filterDefinition, updateDefinition);
        }

        public async Task<List<T>> Search(FilterDefinition<T> filterDefinition)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            return await collection.Find(filterDefinition).ToListAsync();
        }
    }
}
