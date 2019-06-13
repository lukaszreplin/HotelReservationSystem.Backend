using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Services
{
    public class ReservationManager : IReservationManager
    {
        private readonly IMongoDbRepository<Reservation> _repository;

        public ReservationManager(IMongoDbRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<DataResult> Add(Reservation model)
        {
            await _repository.InsertOne(model);
            return DataResultBuilder.Success();
        }

        public async Task<DataResult> Delete(string id)
        {
            await _repository
                .Remove(Builders<Reservation>.Filter.Eq("_id", id));
            return DataResultBuilder.Success();
        }

        public async Task<DataResult> Edit(string id, Reservation model)
        {
            await _repository.Edit(Builders<Reservation>.Filter.Eq("_id", id),
                Builders<Reservation>.Update
                .Set("number", model.Number)
                .Set("from", model.From)
                .Set("to", model.To)
                .Set("room", model.Room));
            return DataResultBuilder.Success();
        }

        public async Task<DataResult<Reservation>> Get(string id)
        {
            return DataResultBuilder.Success(await _repository
                .GetByCondition(Builders<Reservation>.Filter.Eq("_id", id)));
        }

        public async Task<DataResult<List<Reservation>>> GetAll()
        {
            return DataResultBuilder.Success(await _repository.GetAll());
        }
    }
}
