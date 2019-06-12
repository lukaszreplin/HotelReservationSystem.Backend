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


    }
}
