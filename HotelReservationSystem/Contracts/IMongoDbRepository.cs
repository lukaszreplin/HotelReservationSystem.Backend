using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IMongoDbRepository<T> where T : class
    {
        Task InsertOne(T model);

        Task InsertMany(IEnumerable<T> model);

        Task<List<T>> GetAll();

        Task<T> GetByCondition(FilterDefinition<T> filterDefinition);

        Task Remove(FilterDefinition<T> filterDefinition);

        Task Edit(FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition);

        Task<List<T>> Search(FilterDefinition<T> filterDefinition);
    }
}
