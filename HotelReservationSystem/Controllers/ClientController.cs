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
    public class ClientController : ControllerBase
    {
        private readonly IClientManager _clientManager;

        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<DataResult<List<Client>>> Get()
        {
            return await _clientManager.GetAll();
        }

        // GET: api/Client/Search/test
        [HttpGet("Search/{phrase}", Name = "SearchClient")]
        public async Task<DataResult<List<Client>>> Search(string phrase)
        {
            return await _clientManager.SearchClients(phrase);
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "GetClient")]
        public async Task<DataResult<Client>> Get(string id)
        {
            return await _clientManager.GetClient(id);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<DataResult> Post([FromBody] Client model)
        {
            return await _clientManager.Add(model);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<DataResult> Put(string id, [FromBody] Client model)
        {
            return await _clientManager.EditClient(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DataResult> Delete(string id)
        {
            return await _clientManager.DeleteClient(id);
        }
    }
}
