using HotelReservationSystem.Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    [BsonCollection("Rooms")]
    public class Room
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("number")]
        public string Number { get; set; }

        [BsonElement("floor")]
        public string Floor { get; set; }
    }
}
