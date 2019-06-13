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

        Task<DataResult> Add(Room model);

        Task<DataResult<Room>> GetRoom(string id);

        Task<DataResult> DeleteRoom(string id);

        Task<DataResult> EditRoom(string id, Room model);
    }
}
