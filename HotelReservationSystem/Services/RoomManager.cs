using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Services
{
    public class RoomManager : IRoomManager
    {
        private readonly IMongoDbRepository<Room> _repository;

        public RoomManager(IMongoDbRepository<Room> repository)
        {
            _repository = repository;
        }
    }
}
