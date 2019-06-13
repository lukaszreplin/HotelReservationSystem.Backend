using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IClientManager
    {
        Task<DataResult<List<Client>>> GetAll();

        Task<DataResult> Add(Client model);

        Task<DataResult<Client>> GetClient(string id);

        Task<DataResult> DeleteClient(string id);

        Task<DataResult> EditClient(string id, Client model);

        Task<DataResult<List<Client>>> SearchClients(string phrase);
    }
}
