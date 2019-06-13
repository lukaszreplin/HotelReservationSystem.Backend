using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Contracts
{
    public interface IReservationManager
    {
        Task<DataResult<List<Reservation>>> GetAll();

        Task<DataResult> Add(Reservation model);

        Task<DataResult<Reservation>> Get(string id);

        Task<DataResult> Delete(string id);

        Task<DataResult> Edit(string id, Reservation model);
    }
}
