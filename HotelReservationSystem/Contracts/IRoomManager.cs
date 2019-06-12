using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IRoomManager
    {
        Task<DataResult<List<Room>>> GetAll();

        Task Add(Room model);

        Task<Room> GetRoom(string id);
    }
}
