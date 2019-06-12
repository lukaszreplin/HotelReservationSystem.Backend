using AspNetCore.Identity.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class ApplicationUser : MongoIdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
