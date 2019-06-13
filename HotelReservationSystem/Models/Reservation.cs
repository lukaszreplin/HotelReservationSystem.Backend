using HotelReservationSystem.Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    [BsonCollection("Reservations")]
    public class Reservation
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("client")]
        public Client Client { get; set; }

        [BsonElement("number")]
        public string Number { get; set; }

        [BsonElement("from")]
        public DateTime From { get; set; }

        [BsonElement("to")]
        public DateTime To { get; set; }

        [BsonElement("room")]
        public Room Room { get; set; }
    }
}
