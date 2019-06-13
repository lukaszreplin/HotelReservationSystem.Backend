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

        public async Task<DataResult> Add(Room model)
        {
            await _repository.InsertOne(model);
            return DataResultBuilder.Success();
        }

        public async Task<DataResult<List<Room>>> GetAll()
        {
            return DataResultBuilder.Success(await _repository.GetAll());
        }

        public async Task<DataResult<Room>> GetRoom(string id)
        {
            return DataResultBuilder.Success(await _repository.GetByCondition(Builders<Room>.Filter.Eq("_id", id)));
        }

        public async Task<DataResult> DeleteRoom(string roomId)
        {
            await _repository.Remove(Builders<Room>.Filter.Eq("_id", roomId));
            return DataResultBuilder.Success();
        }

        public async Task<DataResult> EditRoom(string id, Room model)
        {
            await _repository.Edit(Builders<Room>.Filter.Eq("_id", id), 
                Builders<Room>.Update
                .Set("number", model.Number)
                .Set("floor", model.Floor));
            return DataResultBuilder.Success();
        }
    }
}
