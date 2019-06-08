﻿using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
