using HotelReservationSystem.Contracts;
using HotelReservationSystem.Infrastructure;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.ServiceCollectionExtensions
{
    public static class AddServices
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<IRoomManager, RoomManager>();
        }
    }
}
