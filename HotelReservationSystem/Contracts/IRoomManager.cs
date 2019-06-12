using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IRoomManager
    {
        Task<List<Room>> GetAll();

        Task Add(Room model);

        Task<Room> GetRoom(string id);
    }
}
