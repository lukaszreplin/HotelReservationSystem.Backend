using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IMongoDbRepository<T> where T : class
    {
    }
}
