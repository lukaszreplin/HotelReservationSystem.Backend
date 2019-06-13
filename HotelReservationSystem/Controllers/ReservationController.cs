using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<DataResult<List<Reservation>>> Get()
        {
            return await _reservationManager.GetAll();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}", Name = "GetReservation")]
        public async Task<DataResult<Reservation>> Get(string id)
        {
            return await _reservationManager.Get(id);
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<DataResult> Post([FromBody] Reservation model)
        {
            return await _reservationManager.Add(model);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<DataResult> Put(string id, [FromBody] Reservation model)
        {
            return await _reservationManager.Edit(id, model);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<DataResult> Delete(string id)
        {
            return await _reservationManager.Delete(id);
        }
    }
}
