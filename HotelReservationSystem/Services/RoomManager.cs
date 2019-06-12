using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public async Task<DataResult<List<Room>>> GetAll()
        {
            return DataResultBuilder.Success(await _repository.GetAll());
        }

        public async Task<Room> GetRoom(string id)
        {
            return await _repository.GetByCondition(Builders<Room>.Filter.Eq("_id", id));
        }
    }
}
