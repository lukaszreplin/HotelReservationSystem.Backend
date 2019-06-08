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

        public async Task Add(Room model)
        {
            await _repository.InsertOne(model);
        }

        public async Task<List<Room>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
