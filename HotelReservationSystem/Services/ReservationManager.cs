﻿using HotelReservationSystem.Contracts;
using HotelReservationSystem.Models;
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


    }
}
