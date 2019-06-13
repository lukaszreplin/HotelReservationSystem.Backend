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
    public class ClientManager : IClientManager
    {
        private readonly IMongoDbRepository<Client> _repository;

        public ClientManager(IMongoDbRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<DataResult> Add(Client model)
        {
            await _repository.InsertOne(model);
            return DataResultBuilder.Success();
        }

        public async Task<DataResult> DeleteClient(string id)
        {
            await _repository
                .Remove(Builders<Client>.Filter.Eq("_id", id));
            return DataResultBuilder.Success();
        }

        public async Task<DataResult> EditClient(string id, Client model)
        {
            await _repository.Edit(Builders<Client>.Filter.Eq("_id", id),
                Builders<Client>.Update
                .Set("location", model.Location)
                .Set("firstname", model.Firstname)
                .Set("lastname", model.Lastname));
            return DataResultBuilder.Success();
        }

        public async Task<DataResult<List<Client>>> GetAll()
        {
            return DataResultBuilder.Success(await _repository.GetAll());
        }

        public async Task<DataResult<Client>> GetClient(string id)
        {
            return DataResultBuilder.Success(await _repository.
                GetByCondition(Builders<Client>.Filter.Eq("_id", id)));
        }

        public async Task<DataResult<List<Client>>> SearchClients(string phrase)
        {
            return DataResultBuilder.Success(await _repository.
                Search(Builders<Client>.Filter.Or(
                    Builders<Client>.Filter.Regex("_id", $".*{phrase}.*"),
                    Builders<Client>.Filter.Regex("location", $".*{phrase}.*"),
                    Builders<Client>.Filter.Regex("firstname", $".*{phrase}.*"),
                    Builders<Client>.Filter.Regex("lastname", $".*{phrase}.*")
                    )));
        }
    }
}
