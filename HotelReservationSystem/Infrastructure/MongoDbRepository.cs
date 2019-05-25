using HotelReservationSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Infrastructure
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : class
    {
    }
}
