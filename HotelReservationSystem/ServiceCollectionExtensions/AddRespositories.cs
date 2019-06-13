using HotelReservationSystem.Contracts;
using HotelReservationSystem.Infrastructure;
using HotelReservationSystem.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.ServiceCollectionExtensions
{
    public static class AddRespositories
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IMongoDbRepository<Reservation>, MongoDbRepository<Reservation>>();
            services.AddScoped<IMongoDbRepository<Room>, MongoDbRepository<Room>>();
            services.AddScoped<IMongoDbRepository<Client>, MongoDbRepository<Client>>();
        }
    }
}
