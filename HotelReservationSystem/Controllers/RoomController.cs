using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<DataResult<List<Room>>> Get()
        {
            return await _roomManager.GetAll();
        }

        // GET: api/Room/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<DataResult<Room>> Get(string id)
        {
            return await _roomManager.GetRoom(id);
        }

        // POST: api/Room
        [HttpPost]
        public async Task<DataResult> Post([FromBody] Room model)
        {
            return await _roomManager.Add(model);
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public async Task<DataResult> Put(string id, [FromBody] Room model)
        {
            return await _roomManager.EditRoom(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DataResult> Delete(string id)
        {
            return await _roomManager.DeleteRoom(id);
        }
    }
}
